using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.ScreenObjects.Rocket.Sprites
{
    class FalconNine : IRocketSprite
    {
        public RectangleF GetBounds(PointF pos, int h)
        {
            var w = getWidth(h);
            return new RectangleF(pos.X - w / 2, pos.Y - h / 2, w, h);
        }

        public List<RocketSpritePiece> GetPointList(PointF pos, int h, IProjectionCalculator  ppCalc, AngularCalculator aCalc)
        {
            var list = new List<RocketSpritePiece>();

            var blackish = Color.FromArgb(50, 50, 50);

            // Center
            var w = getWidth(h);
            var points = new List<PointF>();
            points.Add(ProjectedPoint(pos.X - 1.85F, pos.Y - 24F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 1.7F , pos.Y - 23.5F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 1.5F , pos.Y - 23.1F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 1.4F , pos.Y - 23.0F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 1.25F, pos.Y - 23.0F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 1.1F , pos.Y - 23.2F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 1F   , pos.Y - 23.65F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 0.3F , pos.Y - 30.6F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 0.3F , pos.Y - 30.6F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 1F   , pos.Y - 23.65F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 1.1F , pos.Y - 23.2F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 1.25F, pos.Y - 23.0F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 1.4F , pos.Y - 23.0F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 1.5F , pos.Y - 23.1F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 1.7F , pos.Y - 23.5F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 1.85F, pos.Y - 24F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 1.85F, pos.Y + 5F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 0.6F , pos.Y + 5F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + 0.6F , pos.Y + 6.3F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 0.6F , pos.Y + 6.3F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 0.6F , pos.Y + 5F,  ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - 1.85F, pos.Y + 5F,  ppCalc, aCalc));

            var piece1 = new RocketSpritePiece(points, new SolidBrush(Color.White));
            list.Add(piece1);

            // Missing piece between legs
            var points4 = new List<PointF>();
            points4.Add(ProjectedPoint(pos.X + 0.4F, pos.Y - 30.6F,  ppCalc, aCalc));
            points4.Add(ProjectedPoint(pos.X - 0.4F, pos.Y - 30.6F,  ppCalc, aCalc));
            points4.Add(ProjectedPoint(pos.X, pos.Y - 33.6F,  ppCalc, aCalc));

            var piece4 = new RocketSpritePiece(points4, new SolidBrush(blackish));
            list.Add(piece4);

            // Lower piece under landinlegs
            var lower = new List<PointF>();
            lower.Add(ProjectedPoint(pos.X, pos.Y - 33.4F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 0.05F, pos.Y - 33.53F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 0.13F, pos.Y - 34F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 0.22F, pos.Y - 33.95F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 1.2F , pos.Y - 30.9F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 1.3F , pos.Y - 30.8F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 1.4F , pos.Y - 30.8F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 1.5F , pos.Y - 31F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 1.85F, pos.Y - 32.6F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 1.85F, pos.Y - 34.1F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X - 1.6F , pos.Y - 34.3F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 1.6F, pos.Y - 34.3F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 1.85F, pos.Y - 34.1F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 1.85F, pos.Y - 32.6F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 1.5F, pos.Y - 31F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 1.4F, pos.Y - 30.8F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 1.3F, pos.Y - 30.8F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 1.2F, pos.Y - 30.9F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 0.22F, pos.Y - 33.95F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 0.13F, pos.Y - 34F,  ppCalc, aCalc));
            lower.Add(ProjectedPoint(pos.X + 0.05F, pos.Y - 33.53F,  ppCalc, aCalc));

            var lowerPiece = new RocketSpritePiece(lower, new SolidBrush(blackish));
            list.Add(lowerPiece);


            // Leg left
            var points2 = new List<PointF>();
            points2.Add(ProjectedPoint(pos.X - 1.85F, pos.Y - 24F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.7F , pos.Y - 23.5F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.5F , pos.Y - 23.1F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.4F , pos.Y - 23.0F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.25F, pos.Y - 23.0F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.1F , pos.Y - 23.2F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1F   , pos.Y - 23.65F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X        , pos.Y - 33.4F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 0.05F, pos.Y - 33.53F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 0.13F, pos.Y - 34F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 0.22F, pos.Y - 33.95F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.2F , pos.Y - 30.9F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.3F , pos.Y - 30.8F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.4F , pos.Y - 30.8F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.5F , pos.Y - 31F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 1.85F , pos.Y - 33.6F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 2.0F , pos.Y - 33.5F,  ppCalc, aCalc));
            points2.Add(ProjectedPoint(pos.X - 2.2F , pos.Y - 33.4F,  ppCalc, aCalc));

            var piece2 = new RocketSpritePiece(points2, new SolidBrush(Color.Black));
            list.Add(piece2);

            // leg right
            var points3 = new List<PointF>();
            points3.Add(ProjectedPoint(pos.X + 1.85F, pos.Y - 24F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.7F, pos.Y - 23.5F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.5F, pos.Y - 23.1F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.4F, pos.Y - 23.0F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.25F, pos.Y - 23.0F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.1F, pos.Y - 23.2F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1F, pos.Y - 23.65F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X, pos.Y - 33.4F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 0.05F, pos.Y - 33.53F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 0.13F, pos.Y - 34F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 0.22F, pos.Y - 33.95F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.2F, pos.Y - 30.9F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.3F, pos.Y - 30.8F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.4F, pos.Y - 30.8F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.5F, pos.Y - 31F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 1.85F, pos.Y - 33.6F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 2.0F, pos.Y - 33.5F,  ppCalc, aCalc));
            points3.Add(ProjectedPoint(pos.X + 2.2F, pos.Y - 33.4F,  ppCalc, aCalc));

            var piece3 = new RocketSpritePiece(points3, new SolidBrush(Color.Black));
            list.Add(piece3);

            // gridfins part
            var points5 = new List<PointF>();
            points5.Add(ProjectedPoint(pos.X + 1.85F, pos.Y + 5F,  ppCalc, aCalc));
            points5.Add(ProjectedPoint(pos.X + 0.6F , pos.Y + 5F,  ppCalc, aCalc));
            points5.Add(ProjectedPoint(pos.X + 0.6F , pos.Y + 6.3F,  ppCalc, aCalc));
            points5.Add(ProjectedPoint(pos.X - 0.6F , pos.Y + 6.3F,  ppCalc, aCalc));
            points5.Add(ProjectedPoint(pos.X - 0.6F, pos.Y + 5F,  ppCalc, aCalc));
            points5.Add(ProjectedPoint(pos.X - 1.85F, pos.Y + 5F,  ppCalc, aCalc));
            points5.Add(ProjectedPoint(pos.X - 1.85F, pos.Y + 13F,  ppCalc, aCalc));
            points5.Add(ProjectedPoint(pos.X + 1.85F, pos.Y + 13F,  ppCalc, aCalc));

            var piece5 = new RocketSpritePiece(points5, new SolidBrush(Color.Black));
            list.Add(piece5);

            // 2nd stage
            var points6 = new List<PointF>();
            points6.Add(ProjectedPoint(pos.X + 1.85F, pos.Y + 13F,  ppCalc, aCalc));
            points6.Add(ProjectedPoint(pos.X - 1.85F, pos.Y + 13F,  ppCalc, aCalc));
            points6.Add(ProjectedPoint(pos.X - 1.85F, pos.Y + 22F,  ppCalc, aCalc));
            points6.Add(ProjectedPoint(pos.X + 1.85F, pos.Y + 22F,  ppCalc, aCalc));

            var piece6 = new RocketSpritePiece(points6, new SolidBrush(Color.White));
            list.Add(piece6);

            // Fairing
            var points7 = new List<PointF>();
            points7.Add(ProjectedPoint(pos.X - 1.85F, pos.Y + 22F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X - 2.5F, pos.Y + 23.2F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X - 2.5F, pos.Y + 30.5F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X - 2.24F, pos.Y + 32F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X - 1.8F, pos.Y + 33.3F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X - 1.25F, pos.Y + 34.2F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X - 0.8F, pos.Y + 34.7F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X - 0.35F, pos.Y + 35.1F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X + 0.35F, pos.Y + 35.1F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X + 0.8F, pos.Y + 34.7F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X + 1.25F, pos.Y + 34.2F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X + 1.8F, pos.Y + 33.3F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X + 2.24F, pos.Y + 32F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X + 2.5F, pos.Y + 30.5F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X + 2.5F, pos.Y + 23.2F,  ppCalc, aCalc));
            points7.Add(ProjectedPoint(pos.X + 1.85F, pos.Y + 22F,  ppCalc, aCalc));

            var piece7 = new RocketSpritePiece(points7, new SolidBrush(Color.White));
            list.Add(piece7);

            // Fairing lines
            var points8 = new List<PointF>();
            points8.Add(ProjectedPoint(pos.X - 1.85F, pos.Y + 21.9F,  ppCalc, aCalc));
            points8.Add(ProjectedPoint(pos.X + 1.85F, pos.Y + 21.9F,  ppCalc, aCalc));
            points8.Add(ProjectedPoint(pos.X + 1.85F, pos.Y + 22.1F,  ppCalc, aCalc));
            points8.Add(ProjectedPoint(pos.X - 1.85F, pos.Y + 22.1F,  ppCalc, aCalc));

            var piece8 = new RocketSpritePiece(points8, new SolidBrush(Color.Black));
            list.Add(piece8);
            
            // Fairing lines2
            var points9 = new List<PointF>();
            points9.Add(ProjectedPoint(pos.X - 2.5F, pos.Y + 23.1F,  ppCalc, aCalc));
            points9.Add(ProjectedPoint(pos.X + 2.5F, pos.Y + 23.1F,  ppCalc, aCalc));
            points9.Add(ProjectedPoint(pos.X + 2.5F, pos.Y + 23.3F,  ppCalc, aCalc));
            points9.Add(ProjectedPoint(pos.X - 2.5F, pos.Y + 23.3F,  ppCalc, aCalc));

            var piece9 = new RocketSpritePiece(points9, new SolidBrush(Color.Black));
            list.Add(piece9);

            // nozzles
            var poins10 = new List<PointF>();
            poins10.Add(ProjectedPoint(pos.X - 1.4F, pos.Y - 34.3F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X - 1.5F, pos.Y - 34.4F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X - 1.6F, pos.Y - 34.6F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X - 1.7F, pos.Y - 34.9F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X - 1.75F, pos.Y - 35.3F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X + 1.75F, pos.Y - 35.3F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X + 1.7F, pos.Y - 34.9F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X + 1.6F, pos.Y - 34.6F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X + 1.5F, pos.Y - 34.4F,  ppCalc, aCalc));
            poins10.Add(ProjectedPoint(pos.X + 1.4F, pos.Y - 34.3F,  ppCalc, aCalc));

            var piece10 = new RocketSpritePiece(poins10, new SolidBrush(Color.Black));
            list.Add(piece10);

            // Falcon first piece
            var ff = new List<PointF>();
            ff.Add(ProjectedPoint(pos.X - 1.74F, pos.Y + 1.16F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.69F, pos.Y + 1.02F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.6F, pos.Y + 0.85F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.37F, pos.Y + 0.5F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.11F, pos.Y + 0.21F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 0.87F, pos.Y, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 0.62F, pos.Y - 0.18F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 0.37F, pos.Y - 0.08F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 0.66F, pos.Y + 0.07F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 0.88F, pos.Y + 0.21F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.07F, pos.Y + 0.35F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.25F, pos.Y + 0.5F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.42F, pos.Y + 0.68F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.55F, pos.Y + 0.83F, ppCalc, aCalc));
            ff.Add(ProjectedPoint(pos.X - 1.65F, pos.Y + 0.98F, ppCalc, aCalc));

            var pieceff = new RocketSpritePiece(ff, new SolidBrush(Color.FromArgb(235, 23, 71)));
            list.Add(pieceff);

            // Falcon second piece
            var fs = new List<PointF>();
            fs.Add(ProjectedPoint(pos.X - 1.16F, pos.Y + 0.53F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X - 0.95F, pos.Y + 0.37F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X - 0.59F, pos.Y + 0.14F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X - 0.23F, pos.Y - 0.03F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X - 0.08F, pos.Y + 0.3F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.18F, pos.Y + 0.06F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.33F, pos.Y + 0.08F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.6F, pos.Y + 0.075F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.64F, pos.Y + 0.072F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.66F, pos.Y + 0.061F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.69F, pos.Y + 0.044F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.72F, pos.Y, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.59F, pos.Y + 0.038F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.51F, pos.Y + 0.038F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.45F, pos.Y + 0.026F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.38F, pos.Y, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.485F, pos.Y + 0.005F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.55F, pos.Y - 0.004F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.52F, pos.Y - 0.035F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.55F, pos.Y - 0.037F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.7F, pos.Y - 0.09F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.75F, pos.Y - 0.094F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.66F, pos.Y - 0.16F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.86F, pos.Y - 0.18F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.98F, pos.Y - 0.2F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 1.08F, pos.Y - 0.25F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 1.14F, pos.Y - 0.34F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 1.145F, pos.Y - 0.38F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 1.16F, pos.Y - 0.35F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 1.18F, pos.Y - 0.31F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 1.18F, pos.Y - 0.25F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 1.11F, pos.Y - 0.15F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.97F, pos.Y - 0.07F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.85F, pos.Y - 0.05F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.72F, pos.Y + 0.125F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X + 0.27F, pos.Y + 0.144F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X - 0.26F, pos.Y + 0.22F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X - 0.7F, pos.Y + 0.34F, ppCalc, aCalc));
            fs.Add(ProjectedPoint(pos.X - 0.9F, pos.Y + 0.41F, ppCalc, aCalc));
            var piecefs = new RocketSpritePiece(fs, new SolidBrush(Color.FromArgb(235, 23, 71)));
            list.Add(piecefs);


            return list;
        }

        private PointF ProjectedPoint(float x, float y, IProjectionCalculator p, AngularCalculator aCalc)
        {
            return p.ProjectPoint(aCalc.Turn(new PointF(x, y)));
        }

        private int getWidth(float height) => (int)Math.Round(1F / 3F * height);
    }
}
