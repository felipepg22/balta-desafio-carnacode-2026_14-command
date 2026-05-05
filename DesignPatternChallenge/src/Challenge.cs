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
            Console.WriteLine("=== Editor de Texto - Command Pattern ===\n");

            RunBasicEditorExample();
            RunEditorWithOperationLogExample();
            RunEditorWithStateHistoryExample();
        }

        private static void RunBasicEditorExample()
        {
            Console.WriteLine("=== Exemplo 1: EditorApplication ===");

            var app = new EditorApplication();

            app.TypeText("Hello");
            app.TypeText(" World");
            app.ShowContent();

            app.DeleteCharacters(6);
            app.ShowContent();

            app.MakeBold(0, 5);

            Console.WriteLine("\n=== Undo/Redo ===");
            app.Undo();
            app.Redo();

            app.ShowContent();
        }

        private static void RunEditorWithOperationLogExample()
        {
            Console.WriteLine("\n=== Exemplo 2: EditorWithOperationLog ===");

            var app = new EditorWithOperationLog();

            app.TypeText("Command");
            app.TypeText(" Pattern");
            app.ShowContent();

            app.DeleteCharacters(8);
            app.Undo();
            app.Redo();

            app.ShowOperationLog();
        }

        private static void RunEditorWithStateHistoryExample()
        {
            Console.WriteLine("\n=== Exemplo 3: EditorWithStateHistory ===");

            var app = new EditorWithStateHistory();

            app.StartHistory("greeting");
            app.TypeText("Hello");
            app.TypeText(" World");
            app.MakeBold(0, 5);
            app.StopHistory();

            app.ShowContent();

            Console.WriteLine("\n=== Undo manual ===");
            app.Undo();
            app.ShowContent();

            Console.WriteLine("\n=== Replay history: greeting ===");
            app.ReplayHistory("greeting");
            app.ShowContent();
        }
    }
}
