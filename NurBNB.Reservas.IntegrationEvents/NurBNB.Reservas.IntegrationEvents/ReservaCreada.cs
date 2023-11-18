namespace NurBNB.Reservas.IntegrationEvents
{
    public class ReservaCreada
    {
        public Guid ReservaId { get; set; }
        public Guid PropiedaId { get; set; }
        public string Nombre { get; set; }
    }
}