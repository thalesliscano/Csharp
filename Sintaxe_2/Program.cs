// See https://aka.ms/new-console-template for more information
/*Implemente um programa que simule o funcionamento de uma caixa registradora. Utilize uma pilha para representar os itens comprados e uma fila para representar as ordens de compra. O programa deve permitir adicionar itens à pilha, remover itens da pilha (representando a venda) e adicionar ordens de compra à fila. Exiba os itens vendidos e as ordens de compra à medida que forem processados.|*/

Console.WriteLine("Estamos em um mercado, escolha uns itens abaixo");
Console.WriteLine("Arroz - [1]");
Console.WriteLine("Feijão -[2]");
Console.WriteLine("Carne - [3]");
Console.WriteLine("Sprit - [4]");
Console.WriteLine("Oleo -  [5]");
Console.WriteLine("-----------------------------------------------------");

Console.WriteLine("Faça suas compras, mas antes...");
Console.WriteLine("Quantos itens vai comprar: ");
int quantidadeEscolha = int.Parse(Console.ReadLine());
Stack<string> listaCompras = new Stack<string>();

for(var i = 1; i <= quantidadeEscolha;i++) {
  Console.WriteLine("Pegue seus itens:");

  int escolha = int.Parse(Console.ReadLine());
  string escolhaItem = "";

  switch (escolha) {
    case 1:
      escolhaItem= "Arroz";
      break;
    case 2:
      escolhaItem = "Feijão";
      break;
    case 3:
      escolhaItem = "Carne";
      break;
    case 4:
      escolhaItem = "Sprit";
      break;
    case 5:
      escolhaItem = "Oleo";
      break;
    default:
      Console.WriteLine("Opção inválida");
      continue;
  }
  listaCompras.Push(escolhaItem);
}

Queue<string> listaComprasQueue = new Queue<string>();

Console.WriteLine("Gostaria de remover algum item?")
Console.WriteLine("Quantos itens quer remover: ") 
int quantidadeParaRemover = int.Parse(Console.ReadLine()); // 3
for(var i = 1;i <= quantidadeParaRemover;i++) // i = 1 qRomov = 3

{
  int remover = int.Parse(Console.ReadLine());
  string removerItem = "";

  switch (remover) {
    case 1:
      removerItem = "Arroz";
      break;
    case 2:
      removerItem = "Feijão";
      break;
    case 3:
      removerItem = "Carne";
      break;
    case 4:
      removerItem = "Sprit";
      break;
    case 5:
      removerItem = "Oleo";
      break;
    default:
      Console.WriteLine("Opção inválida");
      continue;
  }

}
foreach(var compras in listaCompras){
  Console.WriteLine($"{contador}° item: {compras.ToUpper()}");  
};
  




