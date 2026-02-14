using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts;
    private Random _random = new Random();

    public GratitudeActivity()
    {
        _name = "Gratitude";
        _description = "This activity will help you focus on gratitude by thinking deeply about things you are thankful for.";

        _prompts = new List<string>
        {
            "What small thing made you smile today?",
            "Who is someone you are grateful for?",
            "What challenge helped you grow?",
            "What is something about yourself you appreciate?",
            "What blessing have you noticed recently?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\n" + GetRandomPrompt());
        Console.WriteLine("\nReflect quietly on this prompt.");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            ShowSpinner(4);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}