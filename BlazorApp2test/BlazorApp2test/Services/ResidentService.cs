using BlazorApp2test.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorApp2test.Services
{
    public class ResidentService
    {

        // private readonly SqlConnection _connection;
        private readonly string _connectionString;

        // public ResidentService(SqlConnection connection)
        public ResidentService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Missing connection string.");
        }


        public List<ResidentModel> BorgereSkoven { get; } = new();
        public List<ResidentModel> BorgereSlottet { get; } = new();

        public void RemoveBorgerSkoven(ResidentModel borger)
        {
            BorgereSkoven.Remove(borger);
        }
        public void RemoveBorgerSlottet(ResidentModel borger)
        {
            BorgereSlottet.Remove(borger);
        }

        public void AddResidentSkoven()
        {
            BorgereSkoven.Add(new ResidentModel
            {
                Id = Guid.NewGuid(),
                Navn = "Ny Borger",
                MedicinTider = "",
                PNTid = "",
                Status = "",
                Risiko = Risiko.Green,
                Handledag = "",
                HandleTidspunkt = "",
                Betaling = ""
            });
        }

        public void AddResidentSlottet()
        {
            BorgereSlottet.Add(new ResidentModel
            {
                Id = Guid.NewGuid(),
                Navn = "Ny Borger",
                MedicinTider = "",
                PNTid = "",
                Status = "",
                Risiko = Risiko.Green,
                Handledag = "",
                HandleTidspunkt = "",
                Betaling = ""
            });
        }

        // Gemmer en borger i databasen
        public async Task<int> SaveResidentAsync(ResidentModel borger)
        {
            var medicinTime = ParseNullableDateTime(borger.MedicinTider);
            var pnTime = ParseNullableDateTime(borger.PNTid);
            var shoppingDay = ParseNullableDateTime(borger.Handledag);
            var shoppingTime = ParseNullableDateTime(borger.HandleTidspunkt);

            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            await using var transaction = await connection.BeginTransactionAsync();

            try
            {
                int? medicinTimeId = null;
                int? pnId = null;
                int? shoppingId = null;
                int residentId;

                // Insert MedicinTime only if a valid time exists
                if (medicinTime.HasValue)
                {
                    await using var cmd = new SqlCommand(@"
                INSERT INTO dbo.MedicinTime (MeidicinTime)
                VALUES (@MedicinTime);
                SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        connection, (SqlTransaction)transaction);

                    cmd.Parameters.Add("@MedicinTime", SqlDbType.DateTime).Value = medicinTime.Value;
                    medicinTimeId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }

                // Insert PNMedicin only if PN time exists
                if (pnTime.HasValue)
                {
                    await using var cmd = new SqlCommand(@"
                INSERT INTO dbo.PNMedicin (PNTime, Reason, PNTimeStamp)
                VALUES (@PNTime, @Reason, @PNTimeStamp);
                SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        connection, (SqlTransaction)transaction);

                    cmd.Parameters.Add("@PNTime", SqlDbType.DateTime).Value = pnTime.Value;
                    cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 100).Value = "Ikke angivet";
                    cmd.Parameters.Add("@PNTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;

                    pnId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }

                // Insert Shopping only if both shopping day and shopping time exist
                if (shoppingDay.HasValue && shoppingTime.HasValue)
                {
                    await using var cmd = new SqlCommand(@"
                INSERT INTO dbo.Shopping (ShoppingDay, ShoppingTime, PaymentMethod)
                VALUES (@ShoppingDay, @ShoppingTime, @PaymentMethod);
                SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        connection, (SqlTransaction)transaction);

                    cmd.Parameters.Add("@ShoppingDay", SqlDbType.Date).Value = shoppingDay.Value.Date;
                    cmd.Parameters.Add("@ShoppingTime", SqlDbType.DateTime).Value = shoppingTime.Value;
                    cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar, 100).Value =
                        string.IsNullOrWhiteSpace(borger.Betaling) ? "Ikke angivet" : borger.Betaling;

                    shoppingId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }

                // Always insert Resident
                await using (var cmd = new SqlCommand(@"
            INSERT INTO dbo.Resident
                (ResidentName, MedicinTimeID, PNID, ShoppingID, ResidentStatus, Risk)
            VALUES
                (@ResidentName, @MedicinTimeID, @PNID, @ShoppingID, @ResidentStatus, @Risk);
            SELECT CAST(SCOPE_IDENTITY() AS INT);",
                    connection, (SqlTransaction)transaction))
                {
                    cmd.Parameters.Add("@ResidentName", SqlDbType.NVarChar, 100).Value =
                        string.IsNullOrWhiteSpace(borger.Navn) ? "Ukendt" : borger.Navn;

                    cmd.Parameters.Add("@MedicinTimeID", SqlDbType.Int).Value =
                        medicinTimeId.HasValue ? medicinTimeId.Value : DBNull.Value;

                    cmd.Parameters.Add("@PNID", SqlDbType.Int).Value =
                        pnId.HasValue ? pnId.Value : DBNull.Value;

                    cmd.Parameters.Add("@ShoppingID", SqlDbType.Int).Value =
                        shoppingId.HasValue ? shoppingId.Value : DBNull.Value;

                    cmd.Parameters.Add("@ResidentStatus", SqlDbType.NVarChar, 100).Value =
                        string.IsNullOrWhiteSpace(borger.Status) ? DBNull.Value : borger.Status;

                    cmd.Parameters.Add("@Risk", SqlDbType.NVarChar, 100).Value =
                        borger.Risiko.ToString();

                    residentId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }

                await transaction.CommitAsync();
                return residentId;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static DateTime? ParseNullableDateTime(string? value)
        {
            return DateTime.TryParse(value, out var result) ? result : null;
        }

        // Gemmer alle borgere i Skoven
        public async Task<int> SaveAllSkovenResidentsAsync()
        {
            int savedCount = 0;

            foreach (var borger in BorgereSkoven)
            {
                await SaveResidentAsync(borger);
                savedCount++;
            }

            return savedCount;
        }

        // Gemmer alle borgere i Slottet
        public async Task<int> SaveAllSlottetResidentsAsync()
        {
            int savedCount = 0;

            foreach (var borger in BorgereSlottet)
            {
                await SaveResidentAsync(borger);
                savedCount++;
            }

            return savedCount;
        }
    }
}