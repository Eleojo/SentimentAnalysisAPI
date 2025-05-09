from fastapi import FastAPI
from pydantic import BaseModel
from transformers import AutoTokenizer, TFAutoModelForSequenceClassification
import tensorflow as tf  # ✅ Add this

class SentimentRequest(BaseModel):
    text: str

class SentimentResponse(BaseModel):
    label: str
    score: float

app = FastAPI(
    title="Sentiment Analysis API",
    docs_url="/docs",
    redoc_url="/redoc"
)

# Load tokenizer & model
tokenizer = AutoTokenizer.from_pretrained("distilbert-base-uncased")
model = TFAutoModelForSequenceClassification.from_pretrained(
    r"C:\Users\Eleojo\Downloads\archive (2)\my_local_model", local_files_only=True
)

def predict(text: str) -> SentimentResponse:
    toks = tokenizer(text, padding="max_length", truncation=True,
                     max_length=128, return_tensors="tf")
    logits = model(toks).logits
    probs = tf.nn.softmax(logits, axis=-1)[0].numpy()
    label = "POSITIVE" if probs[1] > probs[0] else "NEGATIVE"
    return SentimentResponse(label=label, score=float(max(probs)))

@app.post("/analyze", response_model=SentimentResponse)
def analyze(req: SentimentRequest):
    return predict(req.text)
