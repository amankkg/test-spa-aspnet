using System;

namespace SolidDemo
{
    public class Srp
    {
        bool status = true;
        int counter = 0;

        public bool ReadStatus() => status;

        public void Toggle() => status = !status;

        public void WriteStatus(bool value)
        {
            status = value;
        }

        public bool ReadAndToggleStatus()
        {
            var result = ReadStatus();
            Toggle();
            return result;
        }

        public int GetNext()
        {
            var result = counter;

            counter = new Random().Next();

            return result;
        }

        // CQS - Command Query Separation
        // CQRS - Command Query Responsibility Segregation
        // READ ONLY
        public int GetCounter() => counter;

        // MUTATION
        public void GenerateNext() => counter = new Random().Next();
    }
}
