// See https://aka.ms/new-console-template for more information
/*Exercício 1 - Listas e Dicionários:

Crie um programa que mantenha uma lista de nomes de pessoas e suas respectivas idades em um dicionário. O programa deve permitir ao usuário adicionar novas pessoas e suas idades à lista e depois exibir a lista completa de pessoas e idades.*/

var dicionario = new Dictionary<string,int>();

Console.WriteLine("Quantos nomes/idades quer adicionar há lista?: ");
int quantidade = int.Parse(Console.ReadLine());

for(int i = 1;i <= quantidade;i++){
  Console.WriteLine("Adicione um nome ao dicionário: ");
  string adicionarNome =  Console.ReadLine();

  Console.WriteLine("Adicione a idade ao dicionário: ");
  int adicionarIdade = int.Parse(Console.ReadLine());

  dicionario.Add(adicionarNome,adicionarIdade);
  /* if(!dicionario.ContainsKey(adicionarNome)){
     dicionario[adicionarNome] = adicionarIdade
   }
  else*/
};
foreach(var itens in dicionario) {
  Console.WriteLine("Nomes: " + itens.Key + "\nIdades: " + itens.Value + "\n");
};




 


