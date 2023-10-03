class quiz
{
public static void Main()
{
    //List of the actual questions
    List<Question> questions = new List<Question>
    {
        new Question("What is the capital of France?", new List<string> {"Berlin", "London", "Paris"}, "Paris"),
        new Question("When was the US declaration of independance signed?", new List<string> {"1776", "1774", "1777"}, "1776"),
        new Question("What is the biggest mammal on earth?", new List<string> {"Blue Whale", "Elephant", "Girrafe"}, "Blue Whale"),
        new Question("Who invented the lightbulb?", new List<string> {"Thomas Edison", "Ada Lovelace", "Ben Franklin"}, "Thomas Edison"),
        new Question("What is 2 + 2?", 4, false),
    };

    int score = 0;
    
    //Checks MultipleChoice questions
    foreach (var question in questions)
    {
        Console.WriteLine(question.QuestionText);

        if (question.IsMultipleChoice)
        {
            for (int i = 0; i < question.AnswerChoices.Count; i++)
        {
            Console.WriteLine($"{i + 1}, {question.AnswerChoices[i]}");
            
        }
        

        Console.Write("Enter your answer number: ");
        int UserChoice = int.Parse(Console.ReadLine()) - 1;
        
        if (UserChoice >= 0 && UserChoice < question.AnswerChoices.Count && question.AnswerChoices[UserChoice] == question.CorrectAnswer)
        {
            Console.WriteLine("Correct!");
            score++;
        }
        else
        {
            Console.WriteLine($"Wrong!!. The correct answer is : {question.CorrectAnswer}");
        }
    }
    //Checks non multiple questions
    else
    {
        if (int.TryParse(Console.ReadLine(), out int UserChoice))
        {
            if (UserChoice == question.CorrectNumber)
            {
                Console.WriteLine("Correct!");
                score++;
            }

            else
            {
                Console.WriteLine($"Wrong!. The correct answer is {question.CorrectNumber}");
            }

        }

        else
            {
                Console.WriteLine("Invalid input. Please enter a number");
            }
        }
    }

    Console.WriteLine($"Your score: {score} out of {questions.Count}");
    }
}

//Declares the questions and the classes
class Question
{
    public string QuestionText { get; }
    public List<string> AnswerChoices { get; }
    public string CorrectAnswer { get; }
    public int CorrectNumber { get; }
    public bool IsMultipleChoice { get; }

    public Question(string questionText, List<string> answerChoices, string correctAnswer)
    {
        QuestionText = questionText;
        AnswerChoices = answerChoices;
        CorrectAnswer = correctAnswer;
        IsMultipleChoice = true;
    }

    public Question(string questionText, int correctNumber, bool isMultipleChoice = true)
    {
        QuestionText = questionText;
        CorrectNumber = correctNumber;
        IsMultipleChoice = isMultipleChoice;
    }
}