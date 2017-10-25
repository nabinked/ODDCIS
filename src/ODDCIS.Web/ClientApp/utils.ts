var utils = {
    serializeObject(obj: Object, prefix?: string): string {
        var str = [];
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop)) {
                var key = prefix ? prefix + "." + prop : prop;
                var value = (<any>obj)[prop];
                if (value !== null) {
                    str.push((typeof value === "object") ?
                        this.serializeObject(value, key) :
                        encodeURIComponent(key) + "=" + encodeURIComponent(value));

                }
            }
        }
        return str.join("&");
    },

    serializeArray(arr: Array<any>, prefix: string) {
        var str = [];
        for (var i = 0; i < arr.length; i++) {
            var element = arr[i];
            var k = prefix ? prefix + "[" + i + "]" : i.toString();
            var v = arr[i];
            if (v !== null) {
                str.push((typeof v === "object") ?
                    this.serializeObject(v, k) :
                    encodeURIComponent(k) + "=" + encodeURIComponent(v));
            }

        }
        return str.join("&");
    },
    truncate(str: string, length: number) {
        return (str.length > length) ? str.substr(0, length - 1) + '...' : str;
    }
}

export default utils;