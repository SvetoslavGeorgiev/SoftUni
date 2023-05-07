function createAssemblyLine() {
    let result = {
        hasClima: function (myCar) {
            myCar.temp = 21;
            myCar.tempSettings = 21;
            myCar.adjustTemp = () => {
                if (myCar.temp < myCar.tempSettings) {
                    myCar.temp++;
                } else if (myCar.temp > myCar.tempSettings) {
                    myCar.temp--;
                }
            }
        },

        hasAudio: function (myCar) {
            myCar.currentTrack = {},
                myCar.nowPlaying = () => {
                    if (!myCar.currentTrack) {
                        console.log(`Now playing '${myCar.currentTrack.name}' by ${myCar.currentTrack.artist}`);
                    }
                }
        },

        hasParktronic: function (myCar) {
            myCar.checkDistance = (distance) => {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                } else if (distance < 0.25) {
                    console.log("Beep! Beep!");
                } else if (distance < 0.5) {
                    console.log("Beep!");
                } else {
                    console.log('');
                }
            }
        }
    };

    return result;
}
const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);

