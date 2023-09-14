// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Stack<string> pilha = new Stack<string>();

        pilha.Push("Primeiro");
        pilha.Push("Segundo");
        pilha.Push("Terceiro");

        // Transferir os elementos da pilha para uma lista
        List<string> lista = pilha.ToList();

        // Remover o elemento mais antigo da lista
        string elementoRemovido = lista[0];
        lista.RemoveAt(0);

        // Transferir os elementos de volta para a pilha (caso deseje manter a pilha)
        pilha.Clear();
        foreach (var elemento in lista)
        {
            pilha.Push(elemento);
        }

        Console.WriteLine("Elemento mais antigo removido: " + elementoRemovido); // Isso imprimirá "Elemento mais antigo removido: Primeiro"
    }
}

