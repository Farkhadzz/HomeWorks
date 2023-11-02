class Duration {
    constructor(value){
        this.value = value || '00;00';
    }

    convertToSeconds() {
        const [minutes, seconds] = this.value.split(':').map(Number);
        return minutes + ":" + seconds;
    }
}

class Music {
    constructor(name = '', author = '', duration = new Duration()) {
        this.name = name;
        this.author = author;
        this.duration = duration;
    }
}

class MusicCollection {
    constructor(){
        this.musics = [];
    }

    addMusic(name, author, minutes, seconds) {
        const duration = new Duration(minutes, seconds);
        const music = new Music(name, author, duration);
        this.musics.push(music);
    }

    showAll(){
        return this.musics;
    }

    deleteByIndex(index){
        if(index >= 0 && index <= this.musics.length){
            this.musics.splice(index, 1);
        }
    }

    deleteByAuthor(author) {
        this.musics = this.musics.filter(music => music.author !== author);
    }

    deleteByName(name) {
        this.musics = this.musics.filter(music => music.name !== name);
    }

    showFilterByName(name) {
        return this.musics.filter(music => music.name === name);
    }

    showFilterByAuthor(author) {
        return this.musics.filter(music => music.author === author);
    }

}

const music = new MusicCollection();

music.addMusic("Kosandra", "Miyagi", "03:30");
music.addMusic("Captain", "Miyagi", "02:10");

console.log(music.showAll());