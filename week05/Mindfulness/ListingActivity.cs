using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;
    private Random _random = new Random();

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by listing as many items as you can.";

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are your personal strengths?",
            "Who have you helped this week?",
            "When have you felt peace recently?",
            "Who are your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\n" + GetRandomPrompt());
        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}