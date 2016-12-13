using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlowchartEditorMVP.Model
{
    class FlowchartDraw
    {
        private Bitmap btm;
        private Graphics gr;
        int DIST_BETWEEN_BLOCKS = 125;
        int SCROLL_SCALE = 10;

        public Bitmap Draw(OrientedGraph graph, int scroll, int selectedID)
        {
            btm = new Bitmap(500, 800);
            gr = Graphics.FromImage(btm);

            for (int i = 0; i < graph.countNodes(); i++)
            {
                Pen pen;
                if (i == selectedID) pen = new Pen(Color.Red, 3); else pen = new Pen(Color.Black, 3);

                switch (graph.getNodeType(i))
                {
                    case 1:
                        {
                            gr.DrawRectangle(pen, 200 + graph.getNodeShift(i) * 100, 25 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll, 100, 100);
                            break;
                        }
                    case 2:
                        {
                            Point[] p = new Point[4];
                            p[0] = new Point(200 + graph.getNodeShift(i) * 100, 75 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                            p[1] = new Point(250 + graph.getNodeShift(i) * 100, 50 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                            p[2] = new Point(300 + graph.getNodeShift(i) * 100, 75 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                            p[3] = new Point(250 + graph.getNodeShift(i) * 100, 100 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                            gr.DrawPolygon(pen, p);
                            break;
                        }
                    case 3:
                        {
                            gr.DrawEllipse(pen, 200 + graph.getNodeShift(i) * 100, 50 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll, 100, 50);
                            break;
                        }
                    case 5:
                        {
                            Point[] p = new Point[4];
                            p[0] = new Point(200 + graph.getNodeShift(i) * 100, 75 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                            p[1] = new Point(250 + graph.getNodeShift(i) * 100, 50 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                            p[2] = new Point(300 + graph.getNodeShift(i) * 100, 75 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                            p[3] = new Point(250 + graph.getNodeShift(i) * 100, 100 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                            gr.DrawPolygon(pen, p);
                            break;
                        }
                }
                for (int j = 0; j < graph.getAdj()[i].Count; j++)
                {
                    Point p1 = new Point(250 + graph.getNodeShift(i) * 100, 75 + DIST_BETWEEN_BLOCKS * i - SCROLL_SCALE * scroll);
                    Point p2 = new Point(250 + graph.getNodeShift(graph.getAdj()[i][j]) * 100, 75 + DIST_BETWEEN_BLOCKS * graph.getAdj()[i][j] - SCROLL_SCALE * scroll);
                    Drawline(graph.getNodeType(i), graph.getNodeType(graph.getAdj()[i][j]), p1, p2);
                }
            }

            return btm;
        }

        void Drawline(int type1, int type2, Point p1, Point p2)
        {
            if (p1.X == p2.X)
            {
                if (type1 == 5 && p2.Y - p1.Y > DIST_BETWEEN_BLOCKS)
                {
                    p1.X += 50;
                    if (type2 == 1)
                        p2.Y -= 50;
                    else
                        p2.Y -= 25;
                }
                else
                if (p1.Y < p2.Y)
                {
                    if (type1 == 1)
                        p1.Y += 50;
                    else
                        p1.Y += 25;
                    if (type2 == 1)
                        p2.Y -= 50;
                    else
                        p2.Y -= 25;
                }
                else
                {
                    p1.X -= 50;
                    p2.X -= 50;
                }
            }
            else
            {
                if (type1 == 1)
                    p1.Y += 50;
                if (type1 == 2 || type1 == 5)
                    if (p1.X < p2.X) p1.X += 50; else p1.X -= 50;

                if (type2 == 1)
                    p2.Y -= 50;
                else
                    p2.Y -= 25;
            }

            if (p1.Y > p2.Y)
            {
                gr.DrawLine(Pens.Black, p1, new Point(p1.X - 50, p1.Y));
                gr.DrawLine(Pens.Black, new Point(p1.X - 50, p1.Y), new Point(p1.X - 50, p2.Y));
                gr.DrawLine(Pens.Black, new Point(p1.X - 50, p2.Y), p2);
            }
            else
            if (p1.X == p2.X) 
            {
                if (type1 == 2)
                {
                    gr.DrawLine(Pens.Black, new Point(p1.X - 50, p1.Y - 25), new Point(p1.X - 100, p1.Y - 25));
                    gr.DrawLine(Pens.Black, new Point(p1.X - 100, p1.Y - 25), new Point(p1.X - 100, p2.Y - 15));
                    gr.DrawLine(Pens.Black, new Point(p1.X - 100, p2.Y - 15), new Point(p2.X, p2.Y - 15));
                    gr.DrawLine(Pens.Black, new Point(p2.X, p2.Y - 15), p2);
                }
                else
                    gr.DrawLine(Pens.Black, p1, p2);
            }
            else
            if (p1.Y < p2.Y)
            {
                if (type1 == 2)
                {
                    gr.DrawLine(Pens.Black, p1, new Point(p2.X, p1.Y));
                    gr.DrawLine(Pens.Black, new Point(p2.X, p1.Y), p2);
                }
                else
                if (type1 == 5)
                {
                    gr.DrawLine(Pens.Black, p1, new Point(p1.X + 50, p1.Y));
                    gr.DrawLine(Pens.Black, new Point(p1.X + 50, p1.Y), new Point(p1.X + 50, p2.Y - 15));
                    gr.DrawLine(Pens.Black, new Point(p1.X + 50, p2.Y - 15), new Point(p2.X, p2.Y - 15));
                    gr.DrawLine(Pens.Black, new Point(p2.X, p2.Y - 15), p2);
                }
                else
                {
                    gr.DrawLine(Pens.Black, p1, new Point(p1.X, p2.Y-15));
                    gr.DrawLine(Pens.Black, new Point(p1.X, p2.Y-15), new Point(p2.X, p2.Y-15));
                    gr.DrawLine(Pens.Black, new Point(p2.X, p2.Y - 15), p2);
                }
            }
        }
    }
}