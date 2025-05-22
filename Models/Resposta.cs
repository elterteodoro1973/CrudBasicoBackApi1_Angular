namespace BackEndAngular.Models
{
    public class Resposta<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T? Dados { get; set; }
        public Resposta()
        {
            Sucesso = true;
            Mensagem = string.Empty;
            Dados = default(T);
        }
    }
}
