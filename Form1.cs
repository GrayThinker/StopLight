// COP 4365 - Spring, 2022
// HW 1 Stoplight problem
// Joseph Shatti

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Stoplights
{
    public partial class Form1 : Form
    {
        StopLight north_light;
        StopLight east_light;
        StopLight west_light;
        StopLight south_light;
    
        public Form1()
        {
            InitializeComponent();
            north_light = new StopLight(StopLight.State.stop);
            east_light = new StopLight(StopLight.State.go);
            west_light = new StopLight(StopLight.State.go);
            south_light = new StopLight(StopLight.State.stop);
        }

        /// <summary>
        /// Name: run
        /// Runs the different stoplight scenarios
        /// </summary>
        void run()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine("North\tEast\tWest\tSouth");
            // Turn all of the lights red.
            north_light.switch_state(StopLight.State.stop);
            east_light.switch_state(StopLight.State.stop);
            west_light.switch_state(StopLight.State.stop);
            south_light.switch_state(StopLight.State.stop);
            update();
            
            while (stopWatch.Elapsed.TotalSeconds < 3)
            {
                time_label.Text = String.Format("Time: {0:0.##}", stopWatch.Elapsed.TotalSeconds);
                update(false);
            }

            // Turn the North light green.
            north_light.switch_state(StopLight.State.go);
            update();
            while (stopWatch.Elapsed.TotalSeconds < 6)
            {
                time_label.Text = String.Format("Time: {0:0.##}", stopWatch.Elapsed.TotalSeconds);
                update(false);
            }
            // Turn the South light green
            south_light.switch_state(StopLight.State.go);
            update();
            while (stopWatch.Elapsed.TotalSeconds < 6)
            {
                time_label.Text = String.Format("Time: {0:0.##}", stopWatch.Elapsed.TotalSeconds);
                update(false);
            }
            // Turn the North light yellow.
            north_light.switch_state(StopLight.State.caution);
            update();
            return;

            //Turn both the North and South lights red.
            north_light.switch_state(StopLight.State.stop);
            south_light.switch_state(StopLight.State.stop);
            update();
            // Turn the East light green.
            east_light.switch_state(StopLight.State.go);
            update();
            // Turn the West light green.
            west_light.switch_state(StopLight.State.go);
            update();
            // Turn both the East and the West lights red.
            east_light.switch_state(StopLight.State.stop);
            west_light.switch_state(StopLight.State.stop);
            update();
        }

        /// <summary>
        /// Name: update
        /// updates the stoplights in the form
        /// </summary>
        void update(bool show=true)
        {
            north_red.Visible = north_light.top_light.get_state();
            north_yellow.Visible = north_light.middle_light.get_state();
            north_green.Visible = north_light.bottom_light.get_state();
            east_red.Visible = east_light.top_light.get_state();
            east_yellow.Visible = east_light.middle_light.get_state();
            east_green.Visible = east_light.bottom_light.get_state();
            west_red.Visible = west_light.top_light.get_state();
            west_yellow.Visible = west_light.middle_light.get_state();
            west_green.Visible = west_light.bottom_light.get_state();
            south_red.Visible = south_light.top_light.get_state();
            south_yellow.Visible = south_light.middle_light.get_state();
            south_green.Visible = south_light.bottom_light.get_state();
            this.Refresh();
            if (show)
            {
                print();
            }
        }

        /// <summary>
        /// Name: print
        /// Prints out stoplight status to command line
        /// </summary>
        void print()
        {
            // north
            if (north_light.top_light.get_state())
            {
                Console.Write("Red\t");
            }
            else if (north_light.middle_light.get_state())
            {
                Console.Write("Yellow\t");
            }
            else if (north_light.bottom_light.get_state())
            {
                Console.Write("Green\t");
            }
            else
            {
                Console.Write("Grey\t");
            }

            // east
            if (east_light.top_light.get_state())
            {
                Console.Write("Red\t");
            }
            else if (east_light.middle_light.get_state())
            {
                Console.Write("Yellow\t");
            }
            else if (east_light.bottom_light.get_state())
            {
                Console.Write("Green\t");
            }
            else
            {
                Console.Write("Grey\t");
            }

            // west
            if (west_light.top_light.get_state())
            {
                Console.Write("Red\t");
            }
            else if (west_light.middle_light.get_state())
            {
                Console.Write("Yellow\t");
            }
            else if (west_light.bottom_light.get_state())
            {
                Console.Write("Green\t");
            }
            else
            {
                Console.Write("Grey\t");
            }

            // south
            if (south_light.top_light.get_state())
            {
                Console.Write("Red\t");
            }
            else if (south_light.middle_light.get_state())
            {
                Console.Write("Yellow\t");
            }
            else if (south_light.bottom_light.get_state())
            {
                Console.Write("Green\t");
            }
            else
            {
                Console.Write("Grey\t");
            }
            
            Console.WriteLine();
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            run();
        }
    }
}
