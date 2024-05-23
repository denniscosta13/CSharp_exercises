﻿namespace RocketLibrary.Communication.Request
{

    public class RequestRegisterBookJson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Storage { get; set; } = 1;
    }
}
