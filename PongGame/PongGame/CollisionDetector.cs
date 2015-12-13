using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    public class CollisionDetector
    {
        /// <summary>
        /// Calculates if rectangles describing two sprites
        /// are overlapping on screen.
        /// </summary>
        /// <param name="s1">First sprite</param>
        /// <param name="s2">Second sprite</param>
        /// <returns>Returns true if overlapping</returns>
        public static bool Overlaps(Sprite s1, Sprite s2)
        {
            if (((s1.Position.Y > s2.Position.Y) && (s1.Position.Y < s2.Position.Y + s2.Size.Height))
                || ((s1.Position.Y + s1.Size.Height > s2.Position.Y) && (s1.Position.Y + s1.Size.Height < s2.Position.Y + s2.Size.Height)))
            {
                if (((s1.Position.X > s2.Position.X) && (s1.Position.X < s2.Position.X + s2.Size.Width))
                    || (s1.Position.X + s1.Size.Width > s2.Position.X) && (s1.Position.X + s1.Size.Width < s2.Position.X + s2.Size.Width))
                {
                    return true;
                }
                else { return false; }
            }

            else { return false; }
        }
    }

}
    }
}
