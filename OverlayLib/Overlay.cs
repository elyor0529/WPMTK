﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTK {
    /// <summary>
    /// Every shape supported by the overlay.
    /// </summary>
    public enum Shapes {
        Rectangle,
        Arc,
        Bezier,
        ClosedCurve,
        Curve,
        Ellipse,
        Icon,
        Image,
        GraphicPath,
        Pie,
        Polygon,
        String
    }

    /// <summary>
    /// An Overlay object creates a FormOverlay window and draws shapes over it. You need to specify a <see cref="WPMTK.Process"/> object in the constructor.
    /// </summary>
    public class Overlay {
        private FormOverlay formOverlay;
        internal bool isLocked;
        internal WPMTK.Process process;

        /// <summary>
        /// In case you want to edit the form manually, you can do it here.
        /// </summary>
        public FormOverlay FormOverlay {
            get => !isLocked ? formOverlay : throw new InvalidOperationException("Overlay is locked from modification.");
            set { if (!isLocked) formOverlay = value; else throw new InvalidOperationException("Overlay is locked from modification."); }
        }

        /// <summary>
        /// Draw a new overlay above the specified Process's main window.
        /// </summary>
        /// <param name="process"></param>
        public Overlay(WPMTK.Process process)
        {
            this.process = process;
            FormOverlay = new FormOverlay(process, true);
        }

        /// <summary>
        /// Draw a new overlay above the specified Process's main window.
        /// </summary>
        /// <param name="process"></param>
        /// <param name="isBorderless">You can specify false to keep your overlay window from drawing borderless. (Useful for testing)</param>
        public Overlay(WPMTK.Process process, bool isBorderless)
        {
            this.process = process;
            FormOverlay = new FormOverlay(process, isBorderless);
        }

        /// <summary>
        /// After creating the overlay, you need to specify whether it's visible or not.
        /// </summary>
        /// <param name="visible"></param>
        public void IsOverlayShown(bool visible) {
            if (visible) {
                FormOverlay.Show();
            } else {
                FormOverlay.Hide();
            }
        }

        public void AddShape(Shapes shape, object structData) {
            if (!isLocked) {
                switch (shape) {
                    case Shapes.Rectangle:
                        if (structData is RectangleF) {
                            FormOverlay.AddRectangle((RectangleF)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.Arc:
                        if (structData is Arc) {
                            FormOverlay.AddArc((Arc)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.Bezier:
                        if (structData is PointF) {
                            FormOverlay.AddBezier((PointF)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.ClosedCurve:
                        if (structData is ClosedCurve) {
                            FormOverlay.AddClosedCurve((ClosedCurve)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.Curve:
                        if (structData is Curve) {
                            FormOverlay.AddCurve((Curve)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.Ellipse:
                        if (structData is RectangleF) {
                            FormOverlay.AddEllipse((RectangleF)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.Icon:
                        if (structData is IconStruct) {
                            FormOverlay.AddIcon((IconStruct)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.Image:
                        if (structData is ImageStruct) {
                            FormOverlay.AddImage((ImageStruct)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.GraphicPath:
                        if (structData is GraphicsPath) {
                            FormOverlay.AddGraphicsPaths((GraphicsPath)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.Pie:
                        if (structData is Pie) {
                            FormOverlay.AddPie((Pie)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.Polygon:
                        if (structData is Polygon) {
                            FormOverlay.AddPolygon((Polygon)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                    case Shapes.String:
                        if (structData is StringStruct) {
                            FormOverlay.AddString((StringStruct)structData);
                        } else {
                            throw new InvalidOperationException("structData object does not match the required object.");
                        }
                        break;
                }
                formOverlay.RefreshForm();
            } else {
                throw new InvalidOperationException("Overlay is locked from modification.");
            }
        }




    }
}
