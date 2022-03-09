// COP 4365 - Spring, 2022
// HW 1 Stoplight problem
// Joseph Shatti
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stoplights
{
    // represents a single light bulb
    public class Light
    {
        private string color { get; set; }
        private bool is_on = false;
        public void turn_on() { is_on = true; }
        public void turn_off() { is_on = false; }
        public void toggle() { is_on = !is_on; }

        public Light(string color)
        {
            this.color = color;
        }

        public bool get_state()
        {
            return is_on;
        }
    }

    // Represents a stoplight (made of two lights)
    public class StopLight
    {
        private string GREEN = "#00FF00";
        private string RED = "#FF0000";
        private string YELLOW = "#FFFF00";
        public Light top_light { get; set; }
        public Light middle_light { get; set; }
        public Light bottom_light { get; set; }
        public enum State
        {
            off,   // both lights off
            go,   // top light off, bottom light on, middle light off
            caution, // top light off, bottom light off, middle light on
            stop,  // top light on, bottom light off, middle light off
        }

        // switches the state of the stoplight
        public void switch_state(State new_state)
        {
            switch (new_state)
            {
                case State.off:
                    top_light.turn_off();
                    middle_light.turn_off();
                    bottom_light.turn_off();
                    break;
                case State.go:
                    top_light.turn_off();
                    middle_light.turn_off();
                    bottom_light.turn_on();
                    break;
                case State.stop:
                    top_light.turn_on();
                    middle_light.turn_off();
                    bottom_light.turn_off();
                    break;
                case State.caution:
                    top_light.turn_off();
                    middle_light.turn_on();
                    bottom_light.turn_off();
                    break;
                default:
                    Console.WriteLine("Invalid state");
                    break;
            }
        }

        public StopLight(State initial_state = State.off)
        {
            top_light = new Light(RED);
            middle_light = new Light(YELLOW);
            bottom_light = new Light(GREEN);
            switch_state(initial_state);
        }
    }

}
