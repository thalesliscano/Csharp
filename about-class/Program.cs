// See https://aka.ms/new-console-template for more information
  public class Program
  {
  public static void Main(string[] args)
  {
    var resultado = Cadastro.SomarNumeros(2,3);
    
    var produto = new Cadastro.Produto();
    produto.Descricao = "Teclado";
    produto.SetId(1);
    produto.GetId();

    produto.ImprimiriDescricao();
    Console.WriteLine(produto.GetId());
  }
}