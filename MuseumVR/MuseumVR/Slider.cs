using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumVR
{
    internal class EndSlideException : Exception { 
    
    }
    internal class Slider
    {
        Item item;

        private int curr_slide = 0;

        public Slider(Item item) {
            this.item = item;
        }

        public int Count {
            get { return item.CountChilds; }
        }

        public int Curr
        {
            get { return curr_slide; }
        }

        public Item CurrSlide() {
            return item[curr_slide];
        }

        public Item NextSlide() {
            if (curr_slide + 1 >= Count) {
                throw new EndSlideException();
            }

            return item[++curr_slide];
        }

        public Item PrevSlide()
        {
            if (curr_slide - 1 < 0)
            {
                throw new EndSlideException();
            }

            return item[--curr_slide];
        }


    }
}
