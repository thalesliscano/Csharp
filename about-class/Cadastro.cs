namespace Cadastro 
{

  public static class Calculos 
  {
    public static SomarNumeros(int a, int b)
    {
      return a + b;
    }

  }
  public class Produto
  {
    private int Id {get;set;}
    public string Descricao{get; set;}

    public void ImprimiriDescricao()
    {
      Console.WriteLine(GetId() + " - " + Descricao);
    }
    public void SetId(int id)
  {
    Id = id;
  }

  public int GetId()
  {
    return Id;
  }
  }
  
}