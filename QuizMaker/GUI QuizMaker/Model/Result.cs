﻿namespace QuizMaker.GUI_QuizMaker.Model
{
    public class Result
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Score { get; set; }
        public double time { get; set; }
    }
}
