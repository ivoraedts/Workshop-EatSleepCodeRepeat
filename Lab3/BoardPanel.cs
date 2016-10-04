using System.Collections.Generic;
using System.Drawing;

namespace eu.sig.training.ch05.boardpanel.v1
{
    public class BoardPanel
    {
        public class BoardPanelRenderInput
        {
            public Square square { get; set; }
            public Graphics g { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int w { get; set; }
            public int h { get; set; }
        }

        // tag::render[]
        /// <summary>
        /// Renders a single square on the given graphics context on the specified
        /// rectangle.
        ///
        /// <param name="square">The square to render.</param>
        /// <param name="g">The graphics context to draw on.</param>
        /// <param name="x">The x position to start drawing.</param>
        /// <param name="y">The y position to start drawing.</param>
        /// <param name="w">The width of this square (in pixels.)</param>
        /// <param name="h">The height of this square (in pixels.)</param>
        private void Render(BoardPanelRenderInput input)
        {
            input.square.Sprite.Draw(input.g, input.x, input.y, input.w, input.h);
            foreach (Unit unit in input.square.Occupants)
            {
                unit.Sprite.Draw(input.g, input.x, input.y, input.w, input.h);
            }
        }
        // end::render[]

        public class Sprite
        {
            public void Draw(Graphics g, int x, int y, int w, int h)
            {

            }
        }

        public class Unit
        {
            public Sprite Sprite { get; set; }
        }

        public class Square : Unit
        {

            public IList<Unit> Occupants { get; set; }
        }

    }
}
