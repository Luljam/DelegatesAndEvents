using System;

namespace DelegatesAndEvents
{
    // declaração do Delegate
    public delegate int WorkPerformerdHandler(int hours, Worktype worktype);
    class Program
    {
        static void Main()
        {
            // Instância de delegates como os métodos WorkPerformer
            WorkPerformerdHandler delegate1 = new WorkPerformerdHandler(WorkPerformed1);
            WorkPerformerdHandler delegate2 = new WorkPerformerdHandler(WorkPerformed2);
            WorkPerformerdHandler delegate3 = new WorkPerformerdHandler(WorkPerformed3);

            //delegate1(9, Worktype.GoToMeetings);
            //delegate2(11, Worktype.GenerateReports);
            //DoWork(delegate1);

            // Desta forma fica mais fácil fazer referência a multiplis assinantes
            delegate1 += delegate2 + delegate3;
            int finalHour = delegate1(10, Worktype.GenerateReports);
            Console.WriteLine("Final hour: {0}", finalHour);

            Console.Read();
        }

        static void DoWork(WorkPerformerdHandler del)
        {
            // Aqui poderia instanciar o método WorPerformed1 ou 2, não ficaria dinâmico.
            // Para ficar dinâmico, faço uso do delegate e passo o método que eu quero executar.
            // Este método (DoWork) desconhece a regra por dentro do método WorPerformed1,
            // ele apenas passa os valores executa o que foi passado.
            del(5, Worktype.GoToMeetings);
        }

        // Método mensagem de Work Performed 1
        static int WorkPerformed1(int hours, Worktype worktype)
        {
            Console.WriteLine("Work Performed 1 called - Hour: {0} Work: {1}", hours, worktype);
            return hours + 1;
        }

        // Método mensagem de Work Performed 2
        static int WorkPerformed2(int hours, Worktype worktype)
        {
            Console.WriteLine("Work Performed 2 called - Hour: {0} Work: {1}", hours, worktype);
            return hours + 2;
        }

        // Método mensagem de Work Performed 3
        static int WorkPerformed3(int hours, Worktype worktype)
        {
            Console.WriteLine("Work Performed 3 called - Hour: {0} Work: {1}", hours, worktype);
            return hours + 3;
        }
    }

    // Lista de tupos de tarefas
    public enum Worktype
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
