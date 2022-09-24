

from datetime import datetime
from unicodedata import decimal
from fastapi import FastAPI
from pydantic import BaseModel
import MobileNet_AI_Inference
import ssl
import http.client
import json
from datetime import date

app = FastAPI(
    servers=[
        
    ],
    root_path="/api/v1",
)

class Image(BaseModel):
    ImageBase64: str
    Filename:str
    


def send2data(prediction,filename):
    import http.client
    import json
    import ssl

    ssl._create_default_https_context = ssl._create_unverified_context
    #print(prediction)
    result=[]
    final=""
    i=1
    result = prediction.split(";")
    final =result[0].split(" ")
    print(" ".join(final[1:]))
    confidence_level=result[1].split("probability=")[1].split(" ")[0]
    #print(confidence_level)
    
    conn = http.client.HTTPSConnection("localhost", 7115)
    payload = json.dumps({
    "date": "2022-09-17T00:00:00",
    "image": str(filename),
    "confidenceLevel": float(confidence_level),
    "classes": str(" ".join(final[1:]))
    })
    headers = {
    'Content-Type': 'application/json'
    }


    conn.request("POST", "/api/AIimage", payload, headers)
    res = conn.getresponse()
    data = res.read()
    #print(data.decode("utf-8"))


@app.post("/AIPrediction")
async def root(image:Image):
    #print(type(image))
    #print(image.ImageBase64.split("data:image/png;base64,")[1])
    #print(image.ImageBase64)
    #image.ImageBase64 = str(MobileNet_AI_Inference.run())
    #print(image.ImageBase64.split("data:image/png;base64,")[1])
    prediction= MobileNet_AI_Inference.run(image.ImageBase64.split("base64,")[1],image.Filename)
    send2data(prediction,image.Filename)

    return prediction
