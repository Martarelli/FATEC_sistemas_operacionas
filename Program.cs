// Elaborar um programa em C# que calcule vários números fatoriais:
// O programa deve inicialmente perguntar ao usuário a quantidade de cálculos a serem realizados;
// Para cada cálculo o programa deve perguntar ao usuário um número;
// Em seguida, o programa deve iniciar uma thread para cada cálculo, calculando os respectivos fatoriais dos números informados;
// Cada thread deve ter um nome único e deve exibir seu nome junto com a iteração no cálculo do fatorial, mostrando a iteração e o cálculo da iteração. Ao final do cálculo, exibir o resultado do fatorial.
// Exemplo de uma thread calculando o fatorial de 5:

// Thread 3 - Iniciou
// Thread 3 - 5 (cálculo iteração: 5)
// Thread 3 - 4 (cálculo iteração: 20)
// Thread 3 - 3 (cálculo iteração: 60)
// Thread 3 - 2 (cálculo iteração: 120)
// Thread 3 - Resultado 120

void threadUm(){
    Console.WriteLine($"ThreadProc: {Thread.CurrentThread.ManagedThreadId} Ativo");
    Console.Write("Quantidade de repetições de fatoriais: ");
    int n1 = int.Parse(Console.ReadLine());
    Console.WriteLine($"ThreadProc: {Thread.CurrentThread.ManagedThreadId} está iniciando a segunda thread");
    Thread t = new Thread(threadDois);
    t.Start();
    t.Join();

    fat(n1, 100);

}

void threadDois(){
    Console.WriteLine($"ThreadProc: {Thread.CurrentThread.ManagedThreadId} Ativo");
    Console.Write("Quantidade de repetições de fatoriais: ");
    int n2 = int.Parse(Console.ReadLine());
    fat(n2, 100);
}

int fatorial(int x){
    if(x == 0){
        return 1;
    } else {
        return x * fatorial(x-1);
    }
}

void fat(int n, int ms){
    for(int i = 0; i <= n; i++){
        Console.Write("Informe um número para o calculo: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine($"ThreadProc: {Thread.CurrentThread.ManagedThreadId} - Fatorial de {i} = {fatorial(x)}");
        Thread.Sleep(ms);
    }
}

threadUm();