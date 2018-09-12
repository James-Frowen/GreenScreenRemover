# GreenScreenRemover

Removes green background. Command line args `source result threshold`

### default args
source = "./source.png"
result = "./result.png"
threshold = "10"

### How it works

For each pixel, if green is greater than red and blue by threshold given then it is set to transparent.
