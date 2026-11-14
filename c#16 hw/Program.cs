using System;
using System.Collections.Generic;

List<string> studentNames = new List<string>();
Dictionary<string, int> studentScores = new Dictionary<string, int>();

while (true)
{
    Console.WriteLine("\n===== სტუდენტების ქულების მართვის სისტემა =====");
    Console.WriteLine("1. სტუდენტის დამატება");
    Console.WriteLine("2. სტუდენტის ძებნა");
    Console.WriteLine("3. ქულის განახლება");
    Console.WriteLine("4. ყველა სტუდენტის ჩვენება");
    Console.WriteLine("5. გამოსვლა");
    Console.Write("აირჩიეთ ვარიანტი (1-5): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddStudent();
            break;
        case "2":
            SearchStudent();
            break;
        case "3":
            UpdateScore();
            break;
        case "4":
            ShowAllStudents();
            break;
        case "5":
            Console.WriteLine("პროგრამა დასრულდა.");
            return;
        default:
            Console.WriteLine("❌ არასწორი ვარიანტი. გთხოვთ, აირჩიეთ 1-5.");
            break;
    }
}

void AddStudent()
{
    Console.Write("შეიყვანეთ სტუდენტის სახელი: ");
    string name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("❌ სახელი არ შეიძლება იყოს ცარიელი.");
        return;
    }

    if (studentScores.ContainsKey(name))
    {
        Console.WriteLine("⚠️ ეს სტუდენტი უკვე არსებობს.");
        return;
    }

    Console.Write("შეიყვანეთ ქულა (0-100): ");
    if (!int.TryParse(Console.ReadLine(), out int score) || score < 0 || score > 100)
    {
        Console.WriteLine("❌ ქულა უნდა იყოს 0-დან 100-მდე რიცხვი.");
        return;
    }

    studentNames.Add(name);
    studentScores[name] = score;
    Console.WriteLine($"✅ სტუდენტი '{name}' წარმატებით დაემატა ქულით {score}.");
}

void SearchStudent()
{
    Console.Write("შეიყვანეთ სტუდენტის სახელი: ");
    string name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("❌ სახელი არ შეიძლება იყოს ცარიელი.");
        return;
    }

    if (studentScores.ContainsKey(name))
    {
        Console.WriteLine($"✅ {name}-ის ქულა: {studentScores[name]}");
    }
    else
    {
        Console.WriteLine("❌ სტუდენტი ვერ მოიძებნა.");
    }
}

void UpdateScore()
{
    Console.Write("შეიყვანეთ სტუდენტის სახელი: ");
    string name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("❌ სახელი არ შეიძლება იყოს ცარიელი.");
        return;
    }

    if (!studentScores.ContainsKey(name))
    {
        Console.WriteLine("❌ სტუდენტი ვერ მოიძებნა.");
        return;
    }

    Console.Write("შეიყვანეთ ახალი ქულა (0-100): ");
    if (!int.TryParse(Console.ReadLine(), out int newScore) || newScore < 0 || newScore > 100)
    {
        Console.WriteLine("❌ ქულა უნდა იყოს 0-დან 100-მდე რიცხვი.");
        return;
    }

    studentScores[name] = newScore;
    Console.WriteLine($"✅ {name}-ის ქულა განახლდა {newScore}-ზე.");
}

void ShowAllStudents()
{
    if (studentNames.Count == 0)
    {
        Console.WriteLine("📭 სტუდენტები ჯერ არ დამატებულა.");
        return;
    }

    Console.WriteLine("\n===== ყველა სტუდენტი =====");
    int number = 1;
    foreach (string name in studentNames)
    {
        int score = studentScores[name];
        Console.WriteLine($"{number}. {name} - ქულა: {score}");
        number++;
    }
}
