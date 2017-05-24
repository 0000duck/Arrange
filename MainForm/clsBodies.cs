using System;
using System.Collections.Generic;
using Microsoft.Kinect;
using System.Threading.Tasks;

namespace MainForm {
    class clsBodies {
        private List<clsBody> bodies = new List<clsBody>();

        public clsBody getBody(int i) {
            if (bodies != null && i < bodies.Count && i > -1) {
                return bodies[i];
            }
            return null;
        }

        public void Append(clsBody body) {
            bodies.Add(body);
        }

        public void Append(IReadOnlyDictionary<JointType, Joint> js) {
            clsBody tempBody = new clsBody();
            foreach (var i in js.Keys) {
                tempBody.Append(js[i]);
            }
            Append(tempBody);
        }

        public void Draw() {
            if (bodies == null) {
                return;
            }
            foreach (var i in bodies) {
                i.Draw();
            }
        }

        public void Draw(int i) {
            if (bodies == null)
                return;
            if (bodies.Count <= i)
                return;
            bodies[i].Draw();
        }

        public override string ToString() {
            if (bodies.Count != 0) {
                var str = bodies[0].ToString();
                foreach (var i in bodies) {
                    str += i.ToString();
                }
                return str;
            }
            return "";
        }
    }
}
