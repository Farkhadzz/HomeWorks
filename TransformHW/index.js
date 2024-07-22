const { Transform } = require('stream');

const arr = [
    { name: 'arr1', key: null },
    { name: 'arr2', key: 2 },
];

const filteringFunc = new Transform({
    objectMode: true,

    transform(chunk, encoding, callback) {
        if (chunk.key !== null) {
            this.push(chunk);
        }

        callback();
    }
});

arr.forEach((element) => {
    filteringFunc.write(element);
});

filteringFunc.end();

filteringFunc.on('data', (chunk) => {
    console.log(chunk);
});