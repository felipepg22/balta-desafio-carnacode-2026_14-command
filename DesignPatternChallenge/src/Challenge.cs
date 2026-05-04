// DESAFIO: Editor de Texto com Undo/Redo
// PROBLEMA: Um editor de texto precisa implementar operações de desfazer/refazer para
// múltiplas ações (digitar, deletar, formatar). O código atual chama métodos diretamente,
// tornando impossível desfazer operações ou implementar histórico de comandos

using System;
using DesignPatternChallenge.Applications;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Editor de Texto - Problema de Undo/Redo ===\n");

            var app = new EditorApplication();

            Console.WriteLine("=== Operações ===");
            app.TypeText("Hello");
            app.TypeText(" World");
            app.ShowContent();

            app.DeleteCharacters(6); // Deletar " World"
            app.ShowContent();

            app.MakeBold(0, 5); // Negrito em "Hello"

            Console.WriteLine("\n=== Tentando Desfazer ===");
            app.Undo();

           

          
        }
    }
}