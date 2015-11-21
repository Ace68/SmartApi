namespace SmartApi.Domain.Commands
{
    public class CreateNominativo
    {
        public readonly string RagioneSociale;

        public CreateNominativo(string ragioneSociale)
        {
            this.RagioneSociale = ragioneSociale;
        }
    }
}
