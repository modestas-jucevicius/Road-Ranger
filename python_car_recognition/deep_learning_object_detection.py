import numpy as np
import cv2
import os

path = os.path.dirname(os.path.abspath(__file__))
args = {'image': path + '\images\example.jpg',
        'prototxt': path + '\MobileNetSSD_deploy.prototxt.txt',
        'model': path + '\MobileNetSSD_deploy.caffemodel',
        'confidence': 0.85}
# initialize the list of class labels MobileNet SSD was trained to
# detect, then generate a set of bounding box colors for each class
CLASSES = ["background", "aeroplane", "bicycle", "bird", "boat",
           "bottle", "bus", "car", "cat", "chair", "cow", "diningtable",
           "dog", "horse", "motorbike", "person", "pottedplant", "sheep",
           "sofa", "train", "tvmonitor"]
COLORS = np.random.uniform(0, 255, size=(len(CLASSES), 3))

# load our serialized model from disk
print("[INFO] loading model...")
net = cv2.dnn.readNetFromCaffe(args["prototxt"], args["model"])

# load the input image and construct an input blob for the image
# by resizing to a fixed 300x300 pixels and then normalizing it
# (note: normalization is done via the authors of the MobileNet SSD
# implementation)
image = cv2.imread(args["image"])
(h, w) = image.shape[:2]
blob = cv2.dnn.blobFromImage(cv2.resize(image, (300, 300)), 0.007843, (300, 300), 127.5)

# pass the blob through the network and obtain the detections and predictions
print("[INFO] computing object detections...")
net.setInput(blob)
detections = net.forward()
crop_img = image
carNumber = 0

# loop over the detections
for i in np.arange(0, detections.shape[2]):
    # extract the confidence (i.e., probability) associated with the prediction
    confidence = detections[0, 0, i, 2]

    # filter out weak detections by ensuring the `confidence` is
    # greater than the minimum confidence
    # and filter out non cars
    if confidence > args["confidence"] and "{}".format(CLASSES[int(detections[0, 0, i, 1])]) == "car":
        carNumber = carNumber + 1
        croppedImageName = "croppedCar" + str(carNumber) + ".jpg"
        # extract the index of the class label from the `detections`,
        # then compute the (x, y)-coordinates of the bounding box for the object
        idx = int(detections[0, 0, i, 1])
        box = detections[0, 0, i, 3:7] * np.array([w, h, w, h])
        (startX, startY, endX, endY) = box.astype("int")
        crop_img = image[startY:endY, startX:endX]
        # save cropped image
        cv2.imwrite("C:\\Users\\Aurimas\\Desktop\RoadRanger\\python_car_recognition\\" + croppedImageName, crop_img)
		
        print("[INFO] " +  croppedImageName + " is saved...")
		
print("[INFO] computation ended...")
# REIKIA ISSAUGOTI IR UZFIKSUOTU AUTOMOBILIU SKAICIU FRAME'e
