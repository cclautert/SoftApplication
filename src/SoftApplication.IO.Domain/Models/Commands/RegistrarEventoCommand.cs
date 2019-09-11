namespace SoftApplication.IO.Domain.Models.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(string pNome, double pValorCalculado)
        {
            Nome = pNome;
            ValorCalculado = ValorCalculado;
        }
    }
}
