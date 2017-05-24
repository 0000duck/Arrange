using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm {
    class constTuples {
        private List<Tuple<JointType, JointType>> bones;
        private static constTuples tuple;
        public const int count = 24;
        private constTuples() {
            bones = new List<Tuple<JointType, JointType>>();
            init();
        }
        private void init() {
            //'Torso 8
            bones.Add(new Tuple<JointType, JointType>(JointType.Head, JointType.Neck));
            bones.Add(new Tuple<JointType, JointType>(JointType.Neck, JointType.SpineShoulder));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.SpineMid));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineMid, JointType.SpineBase));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderRight));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderLeft));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipRight));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipLeft));

            //'Right Arm 5
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.ElbowRight));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.WristRight));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HandRight));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HandTipRight));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.ThumbRight));


            //'Left Arm 5
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.ElbowLeft));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.WristLeft));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HandLeft));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HandTipLeft));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.ThumbLeft));

            //' Right Leg 3
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.KneeRight));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.AnkleRight));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.FootRight));

            //' Left Leg 3
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.KneeLeft));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.AnkleLeft));
            bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.FootLeft));


        }

        public static constTuples getTuples() {
            if (tuple == null)
                tuple = new constTuples();
            return tuple;
        }

        public Tuple<JointType, JointType> getTuple(int i) {
            return bones[i];
        }

    }
}
