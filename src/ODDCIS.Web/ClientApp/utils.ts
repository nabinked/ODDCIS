var utils = {
    serializeObject: function (obj: Object, prefix?: string) {
        var str = [];
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop)) {
                var key = prefix ? prefix + "." + prop : prop;
                var value = obj[prop];
                if (value !== null) {
                    str.push((typeof value === "object") ?
                        this.serializeObject(value, key) :
                        encodeURIComponent(key) + "=" + encodeURIComponent(value));

                }
            }
        }
        return str.join("&");
    },

    serializeArray: function (arr: Array<any>, prefix: string) {
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
    }
}

export default utils;