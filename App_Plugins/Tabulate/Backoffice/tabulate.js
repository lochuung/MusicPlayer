(function () {
    function r(e, n, t) {
        function o(i, f) {
            if (!n[i]) {
                if (!e[i]) {
                    var c = "function" == typeof require && require;
                    if (!f && c) return c(i, !0);
                    if (u) return u(i, !0);
                    var a = new Error("Cannot find module '" + i + "'");
                    throw a.code = "MODULE_NOT_FOUND", a
                }
                var p = n[i] = {exports: {}};
                e[i][0].call(p.exports, function (r) {
                    var n = e[i][1][r];
                    return o(n || r)
                }, p, p.exports, r, e, n, t)
            }
            return n[i].exports
        }

        for (var u = "function" == typeof require && require, i = 0; i < t.length; i++) o(t[i]);
        return o
    }

    return r
})()({
    1: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        Object.defineProperty(exports, "v1", {
            enumerable: true,
            get: function () {
                return _v.default;
            }
        });
        Object.defineProperty(exports, "v3", {
            enumerable: true,
            get: function () {
                return _v2.default;
            }
        });
        Object.defineProperty(exports, "v4", {
            enumerable: true,
            get: function () {
                return _v3.default;
            }
        });
        Object.defineProperty(exports, "v5", {
            enumerable: true,
            get: function () {
                return _v4.default;
            }
        });
        Object.defineProperty(exports, "NIL", {
            enumerable: true,
            get: function () {
                return _nil.default;
            }
        });
        Object.defineProperty(exports, "version", {
            enumerable: true,
            get: function () {
                return _version.default;
            }
        });
        Object.defineProperty(exports, "validate", {
            enumerable: true,
            get: function () {
                return _validate.default;
            }
        });
        Object.defineProperty(exports, "stringify", {
            enumerable: true,
            get: function () {
                return _stringify.default;
            }
        });
        Object.defineProperty(exports, "parse", {
            enumerable: true,
            get: function () {
                return _parse.default;
            }
        });

        var _v = _interopRequireDefault(require("./v1.js"));

        var _v2 = _interopRequireDefault(require("./v3.js"));

        var _v3 = _interopRequireDefault(require("./v4.js"));

        var _v4 = _interopRequireDefault(require("./v5.js"));

        var _nil = _interopRequireDefault(require("./nil.js"));

        var _version = _interopRequireDefault(require("./version.js"));

        var _validate = _interopRequireDefault(require("./validate.js"));

        var _stringify = _interopRequireDefault(require("./stringify.js"));

        var _parse = _interopRequireDefault(require("./parse.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }
    }, {
        "./nil.js": 3,
        "./parse.js": 4,
        "./stringify.js": 8,
        "./v1.js": 9,
        "./v3.js": 10,
        "./v4.js": 12,
        "./v5.js": 13,
        "./validate.js": 14,
        "./version.js": 15
    }],
    2: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        /*
         * Browser-compatible JavaScript MD5
         *
         * Modification of JavaScript MD5
         * https://github.com/blueimp/JavaScript-MD5
         *
         * Copyright 2011, Sebastian Tschan
         * https://blueimp.net
         *
         * Licensed under the MIT license:
         * https://opensource.org/licenses/MIT
         *
         * Based on
         * A JavaScript implementation of the RSA Data Security, Inc. MD5 Message
         * Digest Algorithm, as defined in RFC 1321.
         * Version 2.2 Copyright (C) Paul Johnston 1999 - 2009
         * Other contributors: Greg Holt, Andrew Kepert, Ydnar, Lostinet
         * Distributed under the BSD License
         * See http://pajhome.org.uk/crypt/md5 for more info.
         */
        function md5(bytes) {
            if (typeof bytes === 'string') {
                const msg = unescape(encodeURIComponent(bytes)); // UTF8 escape

                bytes = new Uint8Array(msg.length);

                for (let i = 0; i < msg.length; ++i) {
                    bytes[i] = msg.charCodeAt(i);
                }
            }

            return md5ToHexEncodedArray(wordsToMd5(bytesToWords(bytes), bytes.length * 8));
        }

        /*
         * Convert an array of little-endian words to an array of bytes
         */


        function md5ToHexEncodedArray(input) {
            const output = [];
            const length32 = input.length * 32;
            const hexTab = '0123456789abcdef';

            for (let i = 0; i < length32; i += 8) {
                const x = input[i >> 5] >>> i % 32 & 0xff;
                const hex = parseInt(hexTab.charAt(x >>> 4 & 0x0f) + hexTab.charAt(x & 0x0f), 16);
                output.push(hex);
            }

            return output;
        }

        /**
         * Calculate output length with padding and bit length
         */


        function getOutputLength(inputLength8) {
            return (inputLength8 + 64 >>> 9 << 4) + 14 + 1;
        }

        /*
         * Calculate the MD5 of an array of little-endian words, and a bit length.
         */


        function wordsToMd5(x, len) {
            /* append padding */
            x[len >> 5] |= 0x80 << len % 32;
            x[getOutputLength(len) - 1] = len;
            let a = 1732584193;
            let b = -271733879;
            let c = -1732584194;
            let d = 271733878;

            for (let i = 0; i < x.length; i += 16) {
                const olda = a;
                const oldb = b;
                const oldc = c;
                const oldd = d;
                a = md5ff(a, b, c, d, x[i], 7, -680876936);
                d = md5ff(d, a, b, c, x[i + 1], 12, -389564586);
                c = md5ff(c, d, a, b, x[i + 2], 17, 606105819);
                b = md5ff(b, c, d, a, x[i + 3], 22, -1044525330);
                a = md5ff(a, b, c, d, x[i + 4], 7, -176418897);
                d = md5ff(d, a, b, c, x[i + 5], 12, 1200080426);
                c = md5ff(c, d, a, b, x[i + 6], 17, -1473231341);
                b = md5ff(b, c, d, a, x[i + 7], 22, -45705983);
                a = md5ff(a, b, c, d, x[i + 8], 7, 1770035416);
                d = md5ff(d, a, b, c, x[i + 9], 12, -1958414417);
                c = md5ff(c, d, a, b, x[i + 10], 17, -42063);
                b = md5ff(b, c, d, a, x[i + 11], 22, -1990404162);
                a = md5ff(a, b, c, d, x[i + 12], 7, 1804603682);
                d = md5ff(d, a, b, c, x[i + 13], 12, -40341101);
                c = md5ff(c, d, a, b, x[i + 14], 17, -1502002290);
                b = md5ff(b, c, d, a, x[i + 15], 22, 1236535329);
                a = md5gg(a, b, c, d, x[i + 1], 5, -165796510);
                d = md5gg(d, a, b, c, x[i + 6], 9, -1069501632);
                c = md5gg(c, d, a, b, x[i + 11], 14, 643717713);
                b = md5gg(b, c, d, a, x[i], 20, -373897302);
                a = md5gg(a, b, c, d, x[i + 5], 5, -701558691);
                d = md5gg(d, a, b, c, x[i + 10], 9, 38016083);
                c = md5gg(c, d, a, b, x[i + 15], 14, -660478335);
                b = md5gg(b, c, d, a, x[i + 4], 20, -405537848);
                a = md5gg(a, b, c, d, x[i + 9], 5, 568446438);
                d = md5gg(d, a, b, c, x[i + 14], 9, -1019803690);
                c = md5gg(c, d, a, b, x[i + 3], 14, -187363961);
                b = md5gg(b, c, d, a, x[i + 8], 20, 1163531501);
                a = md5gg(a, b, c, d, x[i + 13], 5, -1444681467);
                d = md5gg(d, a, b, c, x[i + 2], 9, -51403784);
                c = md5gg(c, d, a, b, x[i + 7], 14, 1735328473);
                b = md5gg(b, c, d, a, x[i + 12], 20, -1926607734);
                a = md5hh(a, b, c, d, x[i + 5], 4, -378558);
                d = md5hh(d, a, b, c, x[i + 8], 11, -2022574463);
                c = md5hh(c, d, a, b, x[i + 11], 16, 1839030562);
                b = md5hh(b, c, d, a, x[i + 14], 23, -35309556);
                a = md5hh(a, b, c, d, x[i + 1], 4, -1530992060);
                d = md5hh(d, a, b, c, x[i + 4], 11, 1272893353);
                c = md5hh(c, d, a, b, x[i + 7], 16, -155497632);
                b = md5hh(b, c, d, a, x[i + 10], 23, -1094730640);
                a = md5hh(a, b, c, d, x[i + 13], 4, 681279174);
                d = md5hh(d, a, b, c, x[i], 11, -358537222);
                c = md5hh(c, d, a, b, x[i + 3], 16, -722521979);
                b = md5hh(b, c, d, a, x[i + 6], 23, 76029189);
                a = md5hh(a, b, c, d, x[i + 9], 4, -640364487);
                d = md5hh(d, a, b, c, x[i + 12], 11, -421815835);
                c = md5hh(c, d, a, b, x[i + 15], 16, 530742520);
                b = md5hh(b, c, d, a, x[i + 2], 23, -995338651);
                a = md5ii(a, b, c, d, x[i], 6, -198630844);
                d = md5ii(d, a, b, c, x[i + 7], 10, 1126891415);
                c = md5ii(c, d, a, b, x[i + 14], 15, -1416354905);
                b = md5ii(b, c, d, a, x[i + 5], 21, -57434055);
                a = md5ii(a, b, c, d, x[i + 12], 6, 1700485571);
                d = md5ii(d, a, b, c, x[i + 3], 10, -1894986606);
                c = md5ii(c, d, a, b, x[i + 10], 15, -1051523);
                b = md5ii(b, c, d, a, x[i + 1], 21, -2054922799);
                a = md5ii(a, b, c, d, x[i + 8], 6, 1873313359);
                d = md5ii(d, a, b, c, x[i + 15], 10, -30611744);
                c = md5ii(c, d, a, b, x[i + 6], 15, -1560198380);
                b = md5ii(b, c, d, a, x[i + 13], 21, 1309151649);
                a = md5ii(a, b, c, d, x[i + 4], 6, -145523070);
                d = md5ii(d, a, b, c, x[i + 11], 10, -1120210379);
                c = md5ii(c, d, a, b, x[i + 2], 15, 718787259);
                b = md5ii(b, c, d, a, x[i + 9], 21, -343485551);
                a = safeAdd(a, olda);
                b = safeAdd(b, oldb);
                c = safeAdd(c, oldc);
                d = safeAdd(d, oldd);
            }

            return [a, b, c, d];
        }

        /*
         * Convert an array bytes to an array of little-endian words
         * Characters >255 have their high-byte silently ignored.
         */


        function bytesToWords(input) {
            if (input.length === 0) {
                return [];
            }

            const length8 = input.length * 8;
            const output = new Uint32Array(getOutputLength(length8));

            for (let i = 0; i < length8; i += 8) {
                output[i >> 5] |= (input[i / 8] & 0xff) << i % 32;
            }

            return output;
        }

        /*
         * Add integers, wrapping at 2^32. This uses 16-bit operations internally
         * to work around bugs in some JS interpreters.
         */


        function safeAdd(x, y) {
            const lsw = (x & 0xffff) + (y & 0xffff);
            const msw = (x >> 16) + (y >> 16) + (lsw >> 16);
            return msw << 16 | lsw & 0xffff;
        }

        /*
         * Bitwise rotate a 32-bit number to the left.
         */


        function bitRotateLeft(num, cnt) {
            return num << cnt | num >>> 32 - cnt;
        }

        /*
         * These functions implement the four basic operations the algorithm uses.
         */


        function md5cmn(q, a, b, x, s, t) {
            return safeAdd(bitRotateLeft(safeAdd(safeAdd(a, q), safeAdd(x, t)), s), b);
        }

        function md5ff(a, b, c, d, x, s, t) {
            return md5cmn(b & c | ~b & d, a, b, x, s, t);
        }

        function md5gg(a, b, c, d, x, s, t) {
            return md5cmn(b & d | c & ~d, a, b, x, s, t);
        }

        function md5hh(a, b, c, d, x, s, t) {
            return md5cmn(b ^ c ^ d, a, b, x, s, t);
        }

        function md5ii(a, b, c, d, x, s, t) {
            return md5cmn(c ^ (b | ~d), a, b, x, s, t);
        }

        var _default = md5;
        exports.default = _default;
    }, {}],
    3: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;
        var _default = '00000000-0000-0000-0000-000000000000';
        exports.default = _default;
    }, {}],
    4: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _validate = _interopRequireDefault(require("./validate.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

        function parse(uuid) {
            if (!(0, _validate.default)(uuid)) {
                throw TypeError('Invalid UUID');
            }

            let v;
            const arr = new Uint8Array(16); // Parse ########-....-....-....-............

            arr[0] = (v = parseInt(uuid.slice(0, 8), 16)) >>> 24;
            arr[1] = v >>> 16 & 0xff;
            arr[2] = v >>> 8 & 0xff;
            arr[3] = v & 0xff; // Parse ........-####-....-....-............

            arr[4] = (v = parseInt(uuid.slice(9, 13), 16)) >>> 8;
            arr[5] = v & 0xff; // Parse ........-....-####-....-............

            arr[6] = (v = parseInt(uuid.slice(14, 18), 16)) >>> 8;
            arr[7] = v & 0xff; // Parse ........-....-....-####-............

            arr[8] = (v = parseInt(uuid.slice(19, 23), 16)) >>> 8;
            arr[9] = v & 0xff; // Parse ........-....-....-....-############
            // (Use "/" to avoid 32-bit truncation when bit-shifting high-order bytes)

            arr[10] = (v = parseInt(uuid.slice(24, 36), 16)) / 0x10000000000 & 0xff;
            arr[11] = v / 0x100000000 & 0xff;
            arr[12] = v >>> 24 & 0xff;
            arr[13] = v >>> 16 & 0xff;
            arr[14] = v >>> 8 & 0xff;
            arr[15] = v & 0xff;
            return arr;
        }

        var _default = parse;
        exports.default = _default;
    }, {"./validate.js": 14}],
    5: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;
        var _default = /^(?:[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}|00000000-0000-0000-0000-000000000000)$/i;
        exports.default = _default;
    }, {}],
    6: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = rng;
// Unique ID creation requires a high quality random # generator. In the browser we therefore
// require the crypto API and do not support built-in fallback to lower quality random number
// generators (like Math.random()).
        let getRandomValues;
        const rnds8 = new Uint8Array(16);

        function rng() {
            // lazy load so that environments that need to polyfill have a chance to do so
            if (!getRandomValues) {
                // getRandomValues needs to be invoked in a context where "this" is a Crypto implementation. Also,
                // find the complete implementation of crypto (msCrypto) on IE11.
                getRandomValues = typeof crypto !== 'undefined' && crypto.getRandomValues && crypto.getRandomValues.bind(crypto) || typeof msCrypto !== 'undefined' && typeof msCrypto.getRandomValues === 'function' && msCrypto.getRandomValues.bind(msCrypto);

                if (!getRandomValues) {
                    throw new Error('crypto.getRandomValues() not supported. See https://github.com/uuidjs/uuid#getrandomvalues-not-supported');
                }
            }

            return getRandomValues(rnds8);
        }
    }, {}],
    7: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

// Adapted from Chris Veness' SHA1 code at
// http://www.movable-type.co.uk/scripts/sha1.html
        function f(s, x, y, z) {
            switch (s) {
                case 0:
                    return x & y ^ ~x & z;

                case 1:
                    return x ^ y ^ z;

                case 2:
                    return x & y ^ x & z ^ y & z;

                case 3:
                    return x ^ y ^ z;
            }
        }

        function ROTL(x, n) {
            return x << n | x >>> 32 - n;
        }

        function sha1(bytes) {
            const K = [0x5a827999, 0x6ed9eba1, 0x8f1bbcdc, 0xca62c1d6];
            const H = [0x67452301, 0xefcdab89, 0x98badcfe, 0x10325476, 0xc3d2e1f0];

            if (typeof bytes === 'string') {
                const msg = unescape(encodeURIComponent(bytes)); // UTF8 escape

                bytes = [];

                for (let i = 0; i < msg.length; ++i) {
                    bytes.push(msg.charCodeAt(i));
                }
            } else if (!Array.isArray(bytes)) {
                // Convert Array-like to Array
                bytes = Array.prototype.slice.call(bytes);
            }

            bytes.push(0x80);
            const l = bytes.length / 4 + 2;
            const N = Math.ceil(l / 16);
            const M = new Array(N);

            for (let i = 0; i < N; ++i) {
                const arr = new Uint32Array(16);

                for (let j = 0; j < 16; ++j) {
                    arr[j] = bytes[i * 64 + j * 4] << 24 | bytes[i * 64 + j * 4 + 1] << 16 | bytes[i * 64 + j * 4 + 2] << 8 | bytes[i * 64 + j * 4 + 3];
                }

                M[i] = arr;
            }

            M[N - 1][14] = (bytes.length - 1) * 8 / Math.pow(2, 32);
            M[N - 1][14] = Math.floor(M[N - 1][14]);
            M[N - 1][15] = (bytes.length - 1) * 8 & 0xffffffff;

            for (let i = 0; i < N; ++i) {
                const W = new Uint32Array(80);

                for (let t = 0; t < 16; ++t) {
                    W[t] = M[i][t];
                }

                for (let t = 16; t < 80; ++t) {
                    W[t] = ROTL(W[t - 3] ^ W[t - 8] ^ W[t - 14] ^ W[t - 16], 1);
                }

                let a = H[0];
                let b = H[1];
                let c = H[2];
                let d = H[3];
                let e = H[4];

                for (let t = 0; t < 80; ++t) {
                    const s = Math.floor(t / 20);
                    const T = ROTL(a, 5) + f(s, b, c, d) + e + K[s] + W[t] >>> 0;
                    e = d;
                    d = c;
                    c = ROTL(b, 30) >>> 0;
                    b = a;
                    a = T;
                }

                H[0] = H[0] + a >>> 0;
                H[1] = H[1] + b >>> 0;
                H[2] = H[2] + c >>> 0;
                H[3] = H[3] + d >>> 0;
                H[4] = H[4] + e >>> 0;
            }

            return [H[0] >> 24 & 0xff, H[0] >> 16 & 0xff, H[0] >> 8 & 0xff, H[0] & 0xff, H[1] >> 24 & 0xff, H[1] >> 16 & 0xff, H[1] >> 8 & 0xff, H[1] & 0xff, H[2] >> 24 & 0xff, H[2] >> 16 & 0xff, H[2] >> 8 & 0xff, H[2] & 0xff, H[3] >> 24 & 0xff, H[3] >> 16 & 0xff, H[3] >> 8 & 0xff, H[3] & 0xff, H[4] >> 24 & 0xff, H[4] >> 16 & 0xff, H[4] >> 8 & 0xff, H[4] & 0xff];
        }

        var _default = sha1;
        exports.default = _default;
    }, {}],
    8: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _validate = _interopRequireDefault(require("./validate.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

        /**
         * Convert array of 16 byte values to UUID string format of the form:
         * XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
         */
        const byteToHex = [];

        for (let i = 0; i < 256; ++i) {
            byteToHex.push((i + 0x100).toString(16).substr(1));
        }

        function stringify(arr, offset = 0) {
            // Note: Be careful editing this code!  It's been tuned for performance
            // and works in ways you may not expect. See https://github.com/uuidjs/uuid/pull/434
            const uuid = (byteToHex[arr[offset + 0]] + byteToHex[arr[offset + 1]] + byteToHex[arr[offset + 2]] + byteToHex[arr[offset + 3]] + '-' + byteToHex[arr[offset + 4]] + byteToHex[arr[offset + 5]] + '-' + byteToHex[arr[offset + 6]] + byteToHex[arr[offset + 7]] + '-' + byteToHex[arr[offset + 8]] + byteToHex[arr[offset + 9]] + '-' + byteToHex[arr[offset + 10]] + byteToHex[arr[offset + 11]] + byteToHex[arr[offset + 12]] + byteToHex[arr[offset + 13]] + byteToHex[arr[offset + 14]] + byteToHex[arr[offset + 15]]).toLowerCase(); // Consistency check for valid UUID.  If this throws, it's likely due to one
            // of the following:
            // - One or more input array values don't map to a hex octet (leading to
            // "undefined" in the uuid)
            // - Invalid input values for the RFC `version` or `variant` fields

            if (!(0, _validate.default)(uuid)) {
                throw TypeError('Stringified UUID is invalid');
            }

            return uuid;
        }

        var _default = stringify;
        exports.default = _default;
    }, {"./validate.js": 14}],
    9: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _rng = _interopRequireDefault(require("./rng.js"));

        var _stringify = _interopRequireDefault(require("./stringify.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

// **`v1()` - Generate time-based UUID**
//
// Inspired by https://github.com/LiosK/UUID.js
// and http://docs.python.org/library/uuid.html
        let _nodeId;

        let _clockseq; // Previous uuid creation time


        let _lastMSecs = 0;
        let _lastNSecs = 0; // See https://github.com/uuidjs/uuid for API details

        function v1(options, buf, offset) {
            let i = buf && offset || 0;
            const b = buf || new Array(16);
            options = options || {};
            let node = options.node || _nodeId;
            let clockseq = options.clockseq !== undefined ? options.clockseq : _clockseq; // node and clockseq need to be initialized to random values if they're not
            // specified.  We do this lazily to minimize issues related to insufficient
            // system entropy.  See #189

            if (node == null || clockseq == null) {
                const seedBytes = options.random || (options.rng || _rng.default)();

                if (node == null) {
                    // Per 4.5, create and 48-bit node id, (47 random bits + multicast bit = 1)
                    node = _nodeId = [seedBytes[0] | 0x01, seedBytes[1], seedBytes[2], seedBytes[3], seedBytes[4], seedBytes[5]];
                }

                if (clockseq == null) {
                    // Per 4.2.2, randomize (14 bit) clockseq
                    clockseq = _clockseq = (seedBytes[6] << 8 | seedBytes[7]) & 0x3fff;
                }
            } // UUID timestamps are 100 nano-second units since the Gregorian epoch,
            // (1582-10-15 00:00).  JSNumbers aren't precise enough for this, so
            // time is handled internally as 'msecs' (integer milliseconds) and 'nsecs'
            // (100-nanoseconds offset from msecs) since unix epoch, 1970-01-01 00:00.


            let msecs = options.msecs !== undefined ? options.msecs : Date.now(); // Per 4.2.1.2, use count of uuid's generated during the current clock
            // cycle to simulate higher resolution clock

            let nsecs = options.nsecs !== undefined ? options.nsecs : _lastNSecs + 1; // Time since last uuid creation (in msecs)

            const dt = msecs - _lastMSecs + (nsecs - _lastNSecs) / 10000; // Per 4.2.1.2, Bump clockseq on clock regression

            if (dt < 0 && options.clockseq === undefined) {
                clockseq = clockseq + 1 & 0x3fff;
            } // Reset nsecs if clock regresses (new clockseq) or we've moved onto a new
            // time interval


            if ((dt < 0 || msecs > _lastMSecs) && options.nsecs === undefined) {
                nsecs = 0;
            } // Per 4.2.1.2 Throw error if too many uuids are requested


            if (nsecs >= 10000) {
                throw new Error("uuid.v1(): Can't create more than 10M uuids/sec");
            }

            _lastMSecs = msecs;
            _lastNSecs = nsecs;
            _clockseq = clockseq; // Per 4.1.4 - Convert from unix epoch to Gregorian epoch

            msecs += 12219292800000; // `time_low`

            const tl = ((msecs & 0xfffffff) * 10000 + nsecs) % 0x100000000;
            b[i++] = tl >>> 24 & 0xff;
            b[i++] = tl >>> 16 & 0xff;
            b[i++] = tl >>> 8 & 0xff;
            b[i++] = tl & 0xff; // `time_mid`

            const tmh = msecs / 0x100000000 * 10000 & 0xfffffff;
            b[i++] = tmh >>> 8 & 0xff;
            b[i++] = tmh & 0xff; // `time_high_and_version`

            b[i++] = tmh >>> 24 & 0xf | 0x10; // include version

            b[i++] = tmh >>> 16 & 0xff; // `clock_seq_hi_and_reserved` (Per 4.2.2 - include variant)

            b[i++] = clockseq >>> 8 | 0x80; // `clock_seq_low`

            b[i++] = clockseq & 0xff; // `node`

            for (let n = 0; n < 6; ++n) {
                b[i + n] = node[n];
            }

            return buf || (0, _stringify.default)(b);
        }

        var _default = v1;
        exports.default = _default;
    }, {"./rng.js": 6, "./stringify.js": 8}],
    10: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _v = _interopRequireDefault(require("./v35.js"));

        var _md = _interopRequireDefault(require("./md5.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

        const v3 = (0, _v.default)('v3', 0x30, _md.default);
        var _default = v3;
        exports.default = _default;
    }, {"./md5.js": 2, "./v35.js": 11}],
    11: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = _default;
        exports.URL = exports.DNS = void 0;

        var _stringify = _interopRequireDefault(require("./stringify.js"));

        var _parse = _interopRequireDefault(require("./parse.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

        function stringToBytes(str) {
            str = unescape(encodeURIComponent(str)); // UTF8 escape

            const bytes = [];

            for (let i = 0; i < str.length; ++i) {
                bytes.push(str.charCodeAt(i));
            }

            return bytes;
        }

        const DNS = '6ba7b810-9dad-11d1-80b4-00c04fd430c8';
        exports.DNS = DNS;
        const URL = '6ba7b811-9dad-11d1-80b4-00c04fd430c8';
        exports.URL = URL;

        function _default(name, version, hashfunc) {
            function generateUUID(value, namespace, buf, offset) {
                if (typeof value === 'string') {
                    value = stringToBytes(value);
                }

                if (typeof namespace === 'string') {
                    namespace = (0, _parse.default)(namespace);
                }

                if (namespace.length !== 16) {
                    throw TypeError('Namespace must be array-like (16 iterable integer values, 0-255)');
                } // Compute hash of namespace and value, Per 4.3
                // Future: Use spread syntax when supported on all platforms, e.g. `bytes =
                // hashfunc([...namespace, ... value])`


                let bytes = new Uint8Array(16 + value.length);
                bytes.set(namespace);
                bytes.set(value, namespace.length);
                bytes = hashfunc(bytes);
                bytes[6] = bytes[6] & 0x0f | version;
                bytes[8] = bytes[8] & 0x3f | 0x80;

                if (buf) {
                    offset = offset || 0;

                    for (let i = 0; i < 16; ++i) {
                        buf[offset + i] = bytes[i];
                    }

                    return buf;
                }

                return (0, _stringify.default)(bytes);
            } // Function#name is not settable on some platforms (#270)


            try {
                generateUUID.name = name; // eslint-disable-next-line no-empty
            } catch (err) {
            } // For CommonJS default export support


            generateUUID.DNS = DNS;
            generateUUID.URL = URL;
            return generateUUID;
        }
    }, {"./parse.js": 4, "./stringify.js": 8}],
    12: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _rng = _interopRequireDefault(require("./rng.js"));

        var _stringify = _interopRequireDefault(require("./stringify.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

        function v4(options, buf, offset) {
            options = options || {};

            const rnds = options.random || (options.rng || _rng.default)(); // Per 4.4, set bits for version and `clock_seq_hi_and_reserved`


            rnds[6] = rnds[6] & 0x0f | 0x40;
            rnds[8] = rnds[8] & 0x3f | 0x80; // Copy bytes to buffer, if provided

            if (buf) {
                offset = offset || 0;

                for (let i = 0; i < 16; ++i) {
                    buf[offset + i] = rnds[i];
                }

                return buf;
            }

            return (0, _stringify.default)(rnds);
        }

        var _default = v4;
        exports.default = _default;
    }, {"./rng.js": 6, "./stringify.js": 8}],
    13: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _v = _interopRequireDefault(require("./v35.js"));

        var _sha = _interopRequireDefault(require("./sha1.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

        const v5 = (0, _v.default)('v5', 0x50, _sha.default);
        var _default = v5;
        exports.default = _default;
    }, {"./sha1.js": 7, "./v35.js": 11}],
    14: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _regex = _interopRequireDefault(require("./regex.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

        function validate(uuid) {
            return typeof uuid === 'string' && _regex.default.test(uuid);
        }

        var _default = validate;
        exports.default = _default;
    }, {"./regex.js": 5}],
    15: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = void 0;

        var _validate = _interopRequireDefault(require("./validate.js"));

        function _interopRequireDefault(obj) {
            return obj && obj.__esModule ? obj : {default: obj};
        }

        function version(uuid) {
            if (!(0, _validate.default)(uuid)) {
                throw TypeError('Invalid UUID');
            }

            return parseInt(uuid.substr(14, 1), 16);
        }

        var _default = version;
        exports.default = _default;
    }, {"./validate.js": 14}],
    16: [function (require, module, exports) {
        "use strict";

        var _controllersModule = require("./controllers/_controllersModule");

        var _resourcesModule = require("./resources/_resourcesModule");

        var name = 'tabulate';
        angular.module(name, [_controllersModule.ControllersModule, _resourcesModule.ResourcesModule]);
        angular.module('umbraco').requires.push(name);

    }, {"./controllers/_controllersModule": 17, "./resources/_resourcesModule": 22}],
    17: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.ControllersModule = void 0;

        var _tabulate = require("./tabulate.controller");

        var _tabulateDialog = require("./tabulate.dialog.controller");

        var _tabulateMapdialog = require("./tabulate.mapdialog.controller");

        var _tabulateSettings = require("./tabulate.settings.controller");

        var ControllersModule = angular.module('tabulate.controllers', []).controller(_tabulate.TabulateController.name, _tabulate.TabulateController).controller(_tabulateDialog.TabulateDialogController.name, _tabulateDialog.TabulateDialogController).controller(_tabulateMapdialog.TabulateMapDialogController.name, _tabulateMapdialog.TabulateMapDialogController).controller(_tabulateSettings.TabulateSettingsController.name, _tabulateSettings.TabulateSettingsController).name;
        exports.ControllersModule = ControllersModule;

    }, {
        "./tabulate.controller": 18,
        "./tabulate.dialog.controller": 19,
        "./tabulate.mapdialog.controller": 20,
        "./tabulate.settings.controller": 21
    }],
    18: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.TabulateController = void 0;

        var _uuid = require("uuid");

        function _createForOfIteratorHelper(o, allowArrayLike) {
            var it;
            if (typeof Symbol === "undefined" || o[Symbol.iterator] == null) {
                if (Array.isArray(o) || (it = _unsupportedIterableToArray(o)) || allowArrayLike && o && typeof o.length === "number") {
                    if (it) o = it;
                    var i = 0;
                    var F = function F() {
                    };
                    return {
                        s: F, n: function n() {
                            if (i >= o.length) return {done: true};
                            return {done: false, value: o[i++]};
                        }, e: function e(_e) {
                            throw _e;
                        }, f: F
                    };
                }
                throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.");
            }
            var normalCompletion = true, didErr = false, err;
            return {
                s: function s() {
                    it = o[Symbol.iterator]();
                }, n: function n() {
                    var step = it.next();
                    normalCompletion = step.done;
                    return step;
                }, e: function e(_e2) {
                    didErr = true;
                    err = _e2;
                }, f: function f() {
                    try {
                        if (!normalCompletion && it["return"] != null) it["return"]();
                    } finally {
                        if (didErr) throw err;
                    }
                }
            };
        }

        function _unsupportedIterableToArray(o, minLen) {
            if (!o) return;
            if (typeof o === "string") return _arrayLikeToArray(o, minLen);
            var n = Object.prototype.toString.call(o).slice(8, -1);
            if (n === "Object" && o.constructor) n = o.constructor.name;
            if (n === "Map" || n === "Set") return Array.from(o);
            if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen);
        }

        function _arrayLikeToArray(arr, len) {
            if (len == null || len > arr.length) len = arr.length;
            for (var i = 0, arr2 = new Array(len); i < len; i++) {
                arr2[i] = arr[i];
            }
            return arr2;
        }

        function ownKeys(object, enumerableOnly) {
            var keys = Object.keys(object);
            if (Object.getOwnPropertySymbols) {
                var symbols = Object.getOwnPropertySymbols(object);
                if (enumerableOnly) symbols = symbols.filter(function (sym) {
                    return Object.getOwnPropertyDescriptor(object, sym).enumerable;
                });
                keys.push.apply(keys, symbols);
            }
            return keys;
        }

        function _objectSpread(target) {
            for (var i = 1; i < arguments.length; i++) {
                var source = arguments[i] != null ? arguments[i] : {};
                if (i % 2) {
                    ownKeys(Object(source), true).forEach(function (key) {
                        _defineProperty(target, key, source[key]);
                    });
                } else if (Object.getOwnPropertyDescriptors) {
                    Object.defineProperties(target, Object.getOwnPropertyDescriptors(source));
                } else {
                    ownKeys(Object(source)).forEach(function (key) {
                        Object.defineProperty(target, key, Object.getOwnPropertyDescriptor(source, key));
                    });
                }
            }
            return target;
        }

        function _classCallCheck(instance, Constructor) {
            if (!(instance instanceof Constructor)) {
                throw new TypeError("Cannot call a class as a function");
            }
        }

        function _defineProperty(obj, key, value) {
            if (key in obj) {
                Object.defineProperty(obj, key, {value: value, enumerable: true, configurable: true, writable: true});
            } else {
                obj[key] = value;
            }
            return obj;
        }

        var TabulateController = function TabulateController($scope, $q, $filter, editorState, authResource, notificationsService, editorService, overlayService, tabulateResource, tabulatePagingService) {
            var _this = this;

            _classCallCheck(this, TabulateController);

            _defineProperty(this, "updateUmbracoModel", function () {
                _this.$scope.model.value.data = _this.data;
                _this.$scope.model.value.settings = _this.settings;
            });

            _defineProperty(this, "emptyModel", function () {
                var newModel = {
                    _guid: (0, _uuid.v4)()
                };

                _this.settings.columns.forEach(function (c) {
                    newModel[c.displayName] = '';
                });

                return newModel;
            });

            _defineProperty(this, "clearModel", function () {
                _this.overlayService.confirmDelete({
                    confirmMessage: 'Do you really want to delete all data?',
                    hideHeader: true,
                    submit: function submit() {
                        _this.data = [];
                        _this.settings = [];
                        _this.pagination = {
                            items: [],
                            currentPage: 1,
                            search: '',
                            pageNumber: 1,
                            pageIndex: 0
                        };
                        _this.$scope.model.value = [];

                        _this.init();

                        _this.overlayService.close();
                    },
                    close: function close() {
                        return _this.overlayService.close();
                    }
                });
            });

            _defineProperty(this, "setSorting", function () {
                _this.manualSort = false;

                if (!_this.settings.sortOrder) {
                    _this.settings.sortOrder = 'A';
                } else if (_this.settings.sortOrder === 'M') {
                    _this.settings.numPerPage = _this.data.length;
                    _this.manualSort = true;
                } else {
                    _this.data = _this.$filter('orderBy')(_this.data, '_label', _this.settings.sortOrder === 'D');
                }

                _this.updateUmbracoModel();
            });

            _defineProperty(this, "removeColumn", function (col) {
                // if this is the last column, get confirmation first, then remove the column and model data
                // otherwise, remove the column if multiple remain
                if (_this.settings.columns.length === 1) {
                    _this.overlayService.confirm({
                        confirmMessage: 'Removing all columns will also delete all stored data. Continue?',
                        hideHeader: true,
                        submit: function submit() {
                            _this.settings = {
                                columns: [],
                                label: '',
                                isListView: false,
                                numPerPage: 10
                            };
                            _this.data = [];

                            _this.setPaging();

                            _this.noConfig = true;

                            _this.overlayService.close();
                        },
                        close: function close() {
                            return _this.overlayService.close();
                        }
                    });
                } else if (_this.settings.columns.length > 1) {
                    var dataLabel = _this.settings.columns[col].displayName;

                    _this.data.forEach(function (item) {
                        if (item.hasOwnProperty(dataLabel)) {
                            delete item[dataLabel];
                        }
                    });

                    _this.settings.columns.splice(col, 1);
                }

                _this.updateUmbracoModel();
            });

            _defineProperty(this, "updateColumns", function (changes) {
                // each change has a new and old value - only continue if new exists ie has been changed
                // i = counter for the outer loop
                // c = changes object for the loop iteration
                // j = counter for the inner loop
                // d = the data object for the inner loop iteration
                var i, c, j, d;

                for (i = 0; i < changes.length; i += 1) {
                    c = changes[i];

                    if (c.newName !== undefined) {
                        // check each value for old name, if it exists update to new
                        for (j = 0; j < _this.data.length; j += 1) {
                            d = _this.data[j]; // has a renamed column, needs updating

                            if (d.hasOwnProperty(c.old)) {
                                // add a new property using the old value, then delete the old property
                                // only if the name has changed
                                if (c.newName !== c.old) {
                                    d[c.newName] = d[c.old];
                                    delete d[c.old];
                                } // update the type, only if it has changed


                                if (d.type !== c.newType) {
                                    d.type = c.newType;
                                }
                            }
                        }
                    }
                }
            });

            _defineProperty(this, "getOverlayBase", function (title, type) {
                return {
                    view: _this.dialogPath,
                    title: title,
                    type: type,
                    size: _this.viewSize,
                    config: _this.settings,
                    rteConfig: _this.rteConfig
                };
            });

            _defineProperty(this, "addRow", function () {
                var addOverlay = _objectSpread(_objectSpread({}, _this.getOverlayBase('Add row', 'add')), {}, {
                    data: _this.emptyModel(),
                    submit: function submit(result) {
                        _this.setRteFields(result); // geocode the model and add it to the model


                        var newItem = _this.mapsLoaded ? _this.tabulateResource.geocode(result.data) : result.data;

                        _this.tabulateResource.setLabels(newItem, true, _this.settings.label);

                        _this.data.push(newItem);

                        _this.afterAddEditRow();
                    },
                    close: function close() {
                        return _this.editorService.close();
                    }
                });

                _this.editorService.open(addOverlay);
            });

            _defineProperty(this, "editRow", function (guid) {
                var idx = _this.data.findIndex(function (d) {
                    return d._guid === guid;
                });

                var originalValue = _objectSpread({}, _this.data[idx]);

                var editOverlay = _objectSpread(_objectSpread({}, _this.getOverlayBase('Edit row', 'edit')), {}, {
                    data: _this.data[idx],
                    submit: function submit(model) {
                        _this.setRteFields(model);

                        var item = model.data; // if the model has a new address, geocode it
                        // then store the model in the model

                        _this.tabulateResource.setLabels(item, true, _this.settings.label);

                        model.recode && _this.mapsLoaded ? _this.tabulateResource.geocode(item) : {}; // send new, old and mappings

                        _this.tabulateResource.updateMappedEditor(item, originalValue, _this.settings.mappings, _this.$scope.model.alias, _this.getCurrentVariant());

                        _this.afterAddEditRow();
                    },
                    close: function close() {
                        return _this.editorService.close();
                    }
                });

                _this.editorService.open(editOverlay);
            });

            _defineProperty(this, "afterAddEditRow", function () {
                _this.editorService.close();

                _this.updateUmbracoModel();

                _this.setSorting();

                _this.setPaging();
            });

            _defineProperty(this, "getCurrentVariant", function () {
                return _this.editorState.current.variants.find(function (v) {
                    return v.active;
                });
            });

            _defineProperty(this, "removeRow", function (guid) {
                var idx = _this.data.findIndex(function (d) {
                    return d._guid === guid;
                });

                if (_this.data.length) {
                    _this.overlayService.confirm({
                        confirmMessage: 'Are you sure you want to remove this item?',
                        hideHeader: true,
                        submit: function submit() {
                            _this.data.splice(idx, 1);

                            _this.updateUmbracoModel();

                            _this.setPaging();

                            _this.overlayService.close();
                        },
                        close: function close() {
                            return _this.overlayService.close();
                        }
                    });
                }
            });

            _defineProperty(this, "disableRow", function (guid) {
                var row = _this.data.find(function (d) {
                    return d._guid === guid;
                });

                var previousValue = _objectSpread({}, row);

                row.disabled = !!row.disabled ? false : true;

                _this.tabulateResource.updateMappedEditor(row, previousValue, _this.settings.mappings, _this.$scope.model.alias, _this.getCurrentVariant());

                _this.updateUmbracoModel();
            });

            _defineProperty(this, "setRteFields", function (model) {
                // get the value from rte fields, if any exist
                if (!model.rteConfig) return;
                var rteKeys = Object.keys(model.rteConfig);

                if (rteKeys.length) {
                    var _iterator = _createForOfIteratorHelper(rteKeys),
                        _step;

                    try {
                        for (_iterator.s(); !(_step = _iterator.n()).done;) {
                            var key = _step.value;
                            model.data[key] = model.rteConfig[key].value;
                        }
                    } catch (err) {
                        _iterator.e(err);
                    } finally {
                        _iterator.f();
                    }
                }
            });

            _defineProperty(this, "openSettings", function () {
                _this.search = '';
                var settingsOverlay = {
                    view: "".concat(_this.basePath, "/overlays/settings.html"),
                    title: 'Settings',
                    size: 'medium',
                    alias: _this.$scope.model.alias,
                    data: _this.data,
                    config: _this.settings,
                    submit: function submit(model) {
                        _this.editorService.close();

                        _this.data = model.data;

                        _this.setSorting();

                        _this.setPaging(); // if the columnsToRemove array exists, remove each config row


                        if (model.columnsToRemove.length > 0) {
                            var _iterator2 = _createForOfIteratorHelper(model.columnsToRemove),
                                _step2;

                            try {
                                for (_iterator2.s(); !(_step2 = _iterator2.n()).done;) {
                                    var col = _step2.value;
                                    removeColumn(col);
                                }
                            } catch (err) {
                                _iterator2.e(err);
                            } finally {
                                _iterator2.f();
                            }
                        } // changes object will exist if changes were made to column names or types


                        var hasColumnChanges = model.changes.some(function (x) {
                            return x.hasOwnProperty('newName') || x.hasOwnProperty('newType');
                        });

                        if (hasColumnChanges) {
                            _this.updateColumns(model.changes);
                        } // if the config has been altered


                        if (hasColumnChanges || model.newColumnName || model.configChanged) {
                            _this.notificationsService.success('Settings updated', 'Don\'t forget to save your changes');
                        } // better force the labels to be reset - not always apparent from checking config changes


                        _this.tabulateResource.setLabels(_this.data, true, _this.settings.label); // finally, if there's nothing left in the config, set the noConfig state


                        _this.noConfig = _this.settings === undefined ? true : false; // need to do this explicitly as it may be imported content

                        _this.updateUmbracoModel();
                    },
                    close: function close() {
                        return _this.editorService.close();
                    }
                };

                _this.editorService.open(settingsOverlay);
            });

            _defineProperty(this, "goToPage", function (pageNumber) {
                _this.pagination.pageIndex = pageNumber - 1;
                _this.pagination.pageNumber = pageNumber;

                _this.setPaging();
            });

            _defineProperty(this, "setPaging", function () {
                _this.pagination = _this.tabulatePagingService.updatePaging(_this.data, _this.pagination.search, _this.pagination.pageNumber, _this.settings.numPerPage);
                _this.noResults = _this.pagination.items.length === 0 && _this.data.length ? true : false;
            });

            _defineProperty(this, "setDataGuids", function () {
                if (_this.data[0]._guid) return;

                _this.data.forEach(function (d) {
                    d._guid = (0, _uuid.v4)();
                });

                _this.notificationsService.info('Tabulate data updated - please save and reload');
            });

            _defineProperty(this, "init", function () {
                if (_this.$scope.model.value === undefined || _this.$scope.model.value.length === 0) {
                    _this.$scope.model.value = {
                        settings: {
                            columns: [],
                            label: '',
                            islistView: false,
                            numPerPage: 10
                        },
                        data: []
                    };
                    _this.data = _this.$scope.model.value.data;
                    _this.settings = _this.$scope.model.value.settings;
                } else if (_this.$scope.model.value.settings) {
                    _this.data = _this.$scope.model.value.data;
                    _this.settings = _this.$scope.model.value.settings;

                    if (_this.data) {
                        _this.setDataGuids();

                        _this.setSorting();

                        _this.setPaging();
                    }
                }

                _this.noConfig = _this.settings.columns.length === 0;
                _this.loading = false;
            });

            this.$scope = $scope;
            this.$filter = $filter;
            this.editorState = editorState;
            this.authResource = authResource;
            this.notificationsService = notificationsService;
            this.editorService = editorService;
            this.overlayService = overlayService;
            this.tabulateResource = tabulateResource;
            this.tabulatePagingService = tabulatePagingService;
            this.basePath = Umbraco.Sys.ServerVariables.umbracoSettings.appPluginsPath + '/Tabulate/Backoffice';
            this.dialogPath = $scope.model.config.customView || "".concat(this.basePath, "/overlays/dialog.html");
            this.viewSize = $scope.model.config.customView ? $scope.model.config.overlaySize : 'small'; // hide the umbraco label if the view is set to wide

            this.$scope.model.hideLabel = $scope.model.config.wide == true;
            this.rteConfig = $scope.model.config.rte; // these don't need to be scoped

            this.data;
            this.settings;
            this.manualSort = false;
            this.hideSettings = true;
            this.pagination = {
                items: [],
                totalPages: 1,
                search: '',
                pageNumber: 1,
                pageIndex: 0
            };
            this.sortOptions = {
                axis: 'y',
                cursor: 'move',
                handle: '.sort-handle',
                stop: function stop() {
                    _this.$scope.model.value.data = _this.data = _this.pagination.items;
                }
            };
            var promises = [tabulateResource.loadGoogleMaps($scope.model.config.mapsApiKey), authResource.getCurrentUser()];
            this.loading = true;
            $q.all(promises).then(function (resp) {
                _this.mapsLoaded = resp[0];
                _this.hideSettings = false;

                if ($scope.model.config.canAccessSettings) {
                    var canAccessSettings = $scope.model.config.canAccessSettings.split(',');
                    _this.hideSettings = !resp[1].userGroups.some(function (x) {
                        return canAccessSettings.includes(x);
                    });
                }

                _this.init();
            });
        } // this is simply for convenience - update data/settings rather than $scope.model.value.data
// need to remember though to call it whenever the data or settings objects are modified
        ;

        exports.TabulateController = TabulateController;

        _defineProperty(TabulateController, "name", 'Tabulate.Controller');

    }, {"uuid": 1}],
    19: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.TabulateDialogController = void 0;

        function _classCallCheck(instance, Constructor) {
            if (!(instance instanceof Constructor)) {
                throw new TypeError("Cannot call a class as a function");
            }
        }

        function _defineProperty(obj, key, value) {
            if (key in obj) {
                Object.defineProperty(obj, key, {value: value, enumerable: true, configurable: true, writable: true});
            } else {
                obj[key] = value;
            }
            return obj;
        }

        var TabulateDialogController = function TabulateDialogController($scope, editorService, editorState, tabulateResource, assetsService, $timeout) {
            var _this = this;

            _classCallCheck(this, TabulateDialogController);

            _defineProperty(this, "$onDestroy", function () {
                _this.addressWatch ? _this.addressWatch() : {};
            });

            _defineProperty(this, "bindLinkedColumn", function (column) {
                var tabulateEditors = _this.tabulateResource.getTabulateEditors(_this.$scope.model.alias, _this.editorState.current.variants.find(function (v) {
                    return v.active;
                }));

                var linkedEditor = tabulateEditors.find(function (t) {
                    return t.alias == column.source;
                });
                var linkedTabulateEditor = linkedEditor.editor === 'NW.Tabulate'; // get the data from the linked editor, depending on alias

                var data = linkedTabulateEditor ? linkedEditor.value.data : linkedEditor.value; // configure typeahead using linked data

                var options = {
                    highlight: true,
                    minLength: 1
                };
                var sources = {
                    name: 'sources',
                    source: new Bloodhound({
                        datumTokenizer: linkedTabulateEditor ? Bloodhound.tokenizers.obj.whitespace('_label') : Bloodhound.tokenizers.whitespace,
                        queryTokenizer: Bloodhound.tokenizers.whitespace,
                        local: data
                    })
                };

                if (linkedTabulateEditor) {
                    sources.displayKey = '_label';
                }

                var typeaheadElement = angular.element('#typeahead_' + _this.safeName(column.displayName));
                typeaheadElement.typeahead(options, sources).bind("typeahead:selected", function (obj, datum, name) {
                    _this.$scope.model.data[column.displayName] = datum._label;
                    _this.$scope.model.data[column.displayName + '_link'] = datum._guid;
                }).bind("typeahead:autocompleted", function (obj, datum, name) {
                    _this.$scope.model.data[column.displayName] = datum._label;
                    _this.$scope.model.data[column.displayName + '_link'] = datum._guid;
                });
            });

            _defineProperty(this, "safeName", function (str) {
                return str.replace(/ /gi, '_');
            });

            _defineProperty(this, "viewLocation", function () {
                var mapOverlay = {
                    view: Umbraco.Sys.ServerVariables.Tabulate.pluginPath + '/overlays/mapDialog.html',
                    lat: _this.$scope.model.data.lat,
                    lng: _this.$scope.model.data.lng,
                    title: 'Update address coordinates',
                    submit: function submit(resp) {
                        _this.editorService.close();

                        var keys = Object.keys(_this.$scope.model.data._Address);

                        if (keys.length === 2) {
                            _this.$scope.model.data._Address[keys[0]] = resp.lat;
                            _this.$scope.model.data._Address[keys[1]] = resp.lng;
                            _this.$scope.model.data.lat = resp.lat;
                            _this.$scope.model.data.lng = resp.lng;
                        }
                    },
                    close: function close() {
                        return _this.editorService.close();
                    }
                };

                _this.editorService.open(mapOverlay);
            });

            _defineProperty(this, "getRteConfig", function (n) {
                return {
                    alias: n.toLowerCase(),
                    config: {
                        editor: _this.$scope.model.rteConfig,
                        hideLabel: true
                    },
                    culture: null,
                    description: '',
                    editor: 'Umbraco.TinyMCE',
                    hideLabel: true,
                    id: n.length,
                    isSensitive: false,
                    label: n,
                    readonly: false,
                    validation: {
                        mandatory: false,
                        pattern: null
                    },
                    value: _this.$scope.model.data[n],
                    view: 'views/propertyeditors/rte/rte.html'
                };
            });

            this.$scope = $scope;
            this.editorService = editorService;
            this.editorState = editorState;
            this.tabulateResource = tabulateResource;

            this.inputType = function (type) {
                return type === 'string' ? 'text' : type;
            }; // view loops through the properties array to build the rte - o will have a value added if the data model contains rte fields


            this.$scope.model.rteConfig = {};
            var rteKeys = this.$scope.model.config.columns.filter(function (x) {
                return x.type === 'rte';
            }).map(function (x) {
                return x.displayName;
            });
            rteKeys.forEach(function (displayName) {
                return _this.$scope.model.rteConfig[displayName] = _this.getRteConfig(displayName);
            }); // check for, and link, linked columns

            var linkedColumns = this.$scope.model.config.columns.filter(function (x) {
                return x.type === 'linked';
            });

            if (linkedColumns.length) {
                assetsService.loadJs('lib/typeahead.js/typeahead.bundle.min.js').then(function () {
                    return $timeout(function () {
                        return linkedColumns.forEach(function (l) {
                            return _this.bindLinkedColumn(l);
                        });
                    });
                });
            } // specific to edit //


            if (this.$scope.model.type === 'edit') {
                this.hasGeocodedAddress = this.$scope.model.data._Address && this.$scope.model.data._Address.lat !== undefined && this.$scope.model.data._Address.lng !== undefined; // if the passed data includes an address, and the value changes
                // set a flag to recode the address

                this.addressWatch = this.$scope.$watch('model.data.Address', function (newVal, oldVal) {
                    if (newVal !== oldVal) {
                        _this.$scope.model.recode = true;
                    }
                });
            }
        };

        exports.TabulateDialogController = TabulateDialogController;

        _defineProperty(TabulateDialogController, "name", "Tabulate.Dialog.Controller");

    }, {}],
    20: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.TabulateMapDialogController = void 0;

        function _classCallCheck(instance, Constructor) {
            if (!(instance instanceof Constructor)) {
                throw new TypeError("Cannot call a class as a function");
            }
        }

        function _defineProperty(obj, key, value) {
            if (key in obj) {
                Object.defineProperty(obj, key, {value: value, enumerable: true, configurable: true, writable: true});
            } else {
                obj[key] = value;
            }
            return obj;
        }

        var TabulateMapDialogController = function TabulateMapDialogController($scope) {
            _classCallCheck(this, TabulateMapDialogController);

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 14,
                center: new google.maps.LatLng($scope.model.lat, $scope.model.lng)
            });
            var marker = new google.maps.Marker({
                map: map,
                position: new google.maps.LatLng($scope.model.lat, $scope.model.lng),
                draggable: true
            });

            var dragend = function dragend(e) {
                if ($scope.model.lat !== e.latLng.lat() || $scope.model.lng !== e.latLng.lng()) {
                    $scope.model.lat = e.latLng.lat();
                    $scope.model.lng = e.latLng.lng();
                }
            };

            google.maps.event.addListener(marker, 'dragend', function (event) {
                dragend(event);
            });
        };

        exports.TabulateMapDialogController = TabulateMapDialogController;

        _defineProperty(TabulateMapDialogController, "name", "Tabulate.MapDialog.Controller");

    }, {}],
    21: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.TabulateSettingsController = void 0;

        function _createForOfIteratorHelper(o, allowArrayLike) {
            var it;
            if (typeof Symbol === "undefined" || o[Symbol.iterator] == null) {
                if (Array.isArray(o) || (it = _unsupportedIterableToArray(o)) || allowArrayLike && o && typeof o.length === "number") {
                    if (it) o = it;
                    var i = 0;
                    var F = function F() {
                    };
                    return {
                        s: F, n: function n() {
                            if (i >= o.length) return {done: true};
                            return {done: false, value: o[i++]};
                        }, e: function e(_e) {
                            throw _e;
                        }, f: F
                    };
                }
                throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.");
            }
            var normalCompletion = true, didErr = false, err;
            return {
                s: function s() {
                    it = o[Symbol.iterator]();
                }, n: function n() {
                    var step = it.next();
                    normalCompletion = step.done;
                    return step;
                }, e: function e(_e2) {
                    didErr = true;
                    err = _e2;
                }, f: function f() {
                    try {
                        if (!normalCompletion && it["return"] != null) it["return"]();
                    } finally {
                        if (didErr) throw err;
                    }
                }
            };
        }

        function _unsupportedIterableToArray(o, minLen) {
            if (!o) return;
            if (typeof o === "string") return _arrayLikeToArray(o, minLen);
            var n = Object.prototype.toString.call(o).slice(8, -1);
            if (n === "Object" && o.constructor) n = o.constructor.name;
            if (n === "Map" || n === "Set") return Array.from(o);
            if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen);
        }

        function _arrayLikeToArray(arr, len) {
            if (len == null || len > arr.length) len = arr.length;
            for (var i = 0, arr2 = new Array(len); i < len; i++) {
                arr2[i] = arr[i];
            }
            return arr2;
        }

        function _classCallCheck(instance, Constructor) {
            if (!(instance instanceof Constructor)) {
                throw new TypeError("Cannot call a class as a function");
            }
        }

        function _defineProperty(obj, key, value) {
            if (key in obj) {
                Object.defineProperty(obj, key, {value: value, enumerable: true, configurable: true, writable: true});
            } else {
                obj[key] = value;
            }
            return obj;
        }

        var TabulateSettingsController = function TabulateSettingsController($scope, $filter, tabulateResource, overlayService, editorState) {
            var _this = this;

            _classCallCheck(this, TabulateSettingsController);

            _defineProperty(this, "$onDestroy", function () {
                _this.watchImportExport();
            });

            _defineProperty(this, "changedColumn", function (columnIndex) {
                _this.$scope.model.changes[columnIndex].newName = _this.$scope.model.config.columns[columnIndex].displayName;
                _this.$scope.model.changes[columnIndex].newType = _this.$scope.model.config.columns[columnIndex].type;
            });

            _defineProperty(this, "setTargetEditorColumns", function (alias) {
                if (!alias) return;

                var target = _this.tabulateEditors.find(function (v) {
                    return v.alias === alias;
                });

                if (target) {
                    _this.targetEditorColumns = target.value.settings.columns;
                }
            });

            _defineProperty(this, "addEmptyItem", function () {
                if (!_this.$scope.model.config.mappings) {
                    _this.$scope.model.config.mappings = [];
                }

                _this.$scope.model.config.mappings.push({});
            });

            _defineProperty(this, "removeMapping", function (index) {
                return _this.$scope.model.config.mappings.splice(index, 1);
            });

            _defineProperty(this, "show", function (type) {
                _this.showing = type;
                _this.importExport = _this.showing === 'json' ? _this.jsonSource : _this.csvSource;
            });

            _defineProperty(this, "addColumn", function () {
                _this.$scope.model.config.columns.push({
                    displayName: _this.newColumnName,
                    type: _this.newColumnType
                });

                _this.newColumnName = null;
                _this.newColumnType = null;
            });

            _defineProperty(this, "removeColumn", function (i) {
                _this.overlayService.confirm({
                    confirmMessage: 'Are you sure you want to remove this column?',
                    hideHeader: true,
                    submit: function submit() {
                        _this.$scope.model.columnsToRemove.push(i); // data is removed on submit


                        _this.$scope.model.config.columns.splice(i); // remove it from the current columns list


                        _this.overlayService.close();
                    },
                    close: function close() {
                        return _this.overlayService.close();
                    }
                });
            });

            _defineProperty(this, "download", function () {
                var filename = "download.".concat(_this.showing);
                var d = JSON.parse(JSON.stringify(_this.importExport)); // we need a copy of the data, not a reference

                if (!navigator.userAgent.match(/msie|trident/i)) {
                    var saving = document.createElement('a');
                    saving.href = "data:attachment/".concat(_this.showing, ",").concat(encodeURIComponent(d));
                    saving.download = filename;
                    saving.click();
                } else {
                    var blob = new Blob([d]);
                    window.navigator.msSaveOrOpenBlob(blob, filename);
                }
            });

            _defineProperty(this, "convertCsvToJson", function (csv) {
                try {
                    var array = _this.tabulateResource.CSVtoArray(csv);

                    var objArray = [];
                    var key;

                    for (var i = 1; i < array.length; i += 1) {
                        objArray[i - 1] = {};

                        for (var j = 0; j < array[0].length && j < array[i].length; j += 1) {
                            key = array[0][j];

                            if (!_this.importKeys.includes(key)) {
                                _this.importKeys.push(key);
                            }

                            objArray[i - 1][key] = array[i][j];
                        }
                    }

                    var json = JSON.stringify(objArray);
                    return json.replace(/\},/g, '},\r\n');
                } catch (e) {
                    _this.setImportAlert('danger', 'Unable to convert CSV to JSON: ' + e);

                    return '';
                }
            });

            _defineProperty(this, "geocodeAddresses", function (index, geoStr, p) {
                var address = _this.$scope.model.data[index];

                _this.geocoder.geocode({
                    'address': address[p]
                }, function (results, status) {
                    /* if the geocoding was successful, add the location to the object, otherwise, set location as undefined to ensure key exists */
                    if (status === google.maps.GeocoderStatus.OK) {
                        address[geoStr] = results[0].geometry.location;
                    } else {
                        address[geoStr] = undefined;

                        _this.setImportAlert('danger', "Geocoding failed for address: ".concat(address[p]));
                    }
                    /* recurse through the data object */


                    if (index + 1 < l) {
                        _this.geocodeAddresses(index + 1, geoStr, p);
                    }
                });
            });

            _defineProperty(this, "importCsv", function () {
                /* parse the csv and push into the data object, provided it is no longer than 250 records */
                var csvToJson = JSON.parse(_this.convertCsvToJson(_this.importExport));

                if (csvToJson.length > 0 && csvToJson.length < 2510) {
                    _this.$scope.model.data = csvToJson;
                    /* prompt for geocoding */

                    /* geocodeAddresses method recurses through the data model */

                    if (_this.importKeys.includes('Address')) {
                        /* accepts seed index, alias for encoded address, alias for source property */
                        if (window.google.maps) {
                            _this.geocoder = new google.maps.Geocoder();

                            _this.geocodeAddresses(0, '_Address', 'Address');
                        } else {
                            _this.setImportAlert('danger', 'Google maps API not available - geocoding failed');
                        }
                    }
                    /* clear the config array and update with the new keys from the csv */


                    _this.$scope.model.config.columns = [];

                    var _iterator = _createForOfIteratorHelper(_this.importKeys),
                        _step;

                    try {
                        for (_iterator.s(); !(_step = _iterator.n()).done;) {
                            var key = _step.value;

                            _this.$scope.model.config.columns.push({
                                displayName: key,
                                type: 'string'
                            });
                        }
                    } catch (err) {
                        _iterator.e(err);
                    } finally {
                        _iterator.f();
                    }

                    _this.afterImport();
                } else {
                    _this.setImportAlert('danger', 'Import failed - dataset must be between 1 and 250 records');
                }
            });

            _defineProperty(this, "importJson", function () {
                try {
                    _this.$scope.model.data = JSON.parse(_this.importExport);

                    _this.afterImport();
                } catch (e) {
                    _this.setImportAlert('danger', 'Import failed - unable to parse JSON input');
                }
            });

            _defineProperty(this, "import", function () {
                _this.importAlert = null;

                if (_this.importExport.length) {
                    _this.overlayService.confirm({
                        confirmMessage: 'Importing will overwrite all existing data. Continue?',
                        hideHeader: true,
                        submit: function submit(_) {
                            if (_this.showing === 'json') {
                                _this.importJson();
                            } else {
                                _this.importCsv();
                            }

                            _this.overlayService.close();
                        },
                        close: function close() {
                            return _this.overlayService.close();
                        }
                    });
                }
            });

            _defineProperty(this, "afterImport", function () {
                /* disable importing, set a flag for config changes and new data */
                _this.importDisabled = true;
                _this.$scope.model.configChanged = true;

                _this.setImportAlert('success', 'Import complete - submit to confirm');
            });

            _defineProperty(this, "setImportAlert", function (state, message) {
                return _this.importAlert = {
                    state: state,
                    message: message
                };
            });

            _defineProperty(this, "sort", function () {
                if (_this.$scope.model.data && _this.$scope.model.config.sortOrder !== 'M') {
                    _this.$scope.model.data = _this.$filter('orderBy')(_this.$scope.model.data, '_label', _this.$scope.model.config.sortOrder === 'D');
                }

                _this.$scope.model.configChanged = true;
            });

            this.$scope = $scope;
            this.$filter = $filter;
            this.tabulateResource = tabulateResource;
            this.overlayService = overlayService;
            this.editorState = editorState;
            this.importKeys = []; // array of header text from imported csv

            this.geocoder;
            this.types = tabulateResource.fieldTypes();
            this.importDisabled = true;
            this.importAlert = null;
            this.showing = 'json';
            this.$scope.model.columnsToRemove = []; // remove an existing column - need to handle data removal

            this.$scope.model.changes = []; // store a copy of the config object for comparison when the modal is submitted
            // for mapping

            this.tabulateEditors = tabulateResource.getTabulateEditors(this.$scope.model.alias, this.editorState.current.variants.find(function (v) {
                return v.active;
            }));

            if (this.$scope.model.config.columns && this.$scope.model.config.columns.length) {
                for (var i = 0; i < this.$scope.model.config.columns.length; i += 1) {
                    /* set default sort order if none exists */
                    if (i === 0 && this.$scope.model.config.columns[i].sortOrder) {
                        this.$scope.model.config.columns[i].sortOrder = 'A';
                    }
                    /* push copy into changes object */


                    this.$scope.model.changes.push({
                        old: this.$scope.model.config.columns[i].displayName
                    });
                } // set a default label to the display name of the first column


                if (this.$scope.model.config.label === '') {
                    this.$scope.model.config.label = "{".concat(this.$scope.model.config.columns[0].displayName, "}");
                }
            }
            /* by default, disable the import button, if there is data, display in the view */


            if (this.$scope.model.data) {
                this.jsonSource = JSON.stringify(this.$scope.model.data);
                this.csvSource = this.tabulateResource.JSONtoCSV(this.$scope.model.data, this.$scope.model.config.columns);
                this.show('json');
            } // when the importExport value changes, only allow importing if that value
            // is different to the original data for that type


            this.watchImportExport = $scope.$watch(function () {
                return _this.importExport;
            }, function (newVal) {
                _this.importDisabled = newVal === (_this.showing === 'json' ? _this.jsonSource : _this.csvSource);
            });
        };

        exports.TabulateSettingsController = TabulateSettingsController;

        _defineProperty(TabulateSettingsController, "name", 'Tabulate.Settings.Controller');

    }, {}],
    22: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.ResourcesModule = void 0;

        var _tabulate = require("./tabulate.resource");

        var _tabulatePaging = require("./tabulate.paging.service");

        var ResourcesModule = angular.module('tabulate.resources', []).service(_tabulate.TabulateResource.name, _tabulate.TabulateResource).service(_tabulatePaging.TabulatePagingService.name, _tabulatePaging.TabulatePagingService).name;
        exports.ResourcesModule = ResourcesModule;

    }, {"./tabulate.paging.service": 23, "./tabulate.resource": 24}],
    23: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.TabulatePagingService = void 0;

        function _typeof(obj) {
            "@babel/helpers - typeof";
            if (typeof Symbol === "function" && typeof Symbol.iterator === "symbol") {
                _typeof = function _typeof(obj) {
                    return typeof obj;
                };
            } else {
                _typeof = function _typeof(obj) {
                    return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj;
                };
            }
            return _typeof(obj);
        }

        function _classCallCheck(instance, Constructor) {
            if (!(instance instanceof Constructor)) {
                throw new TypeError("Cannot call a class as a function");
            }
        }

        function _defineProperty(obj, key, value) {
            if (key in obj) {
                Object.defineProperty(obj, key, {value: value, enumerable: true, configurable: true, writable: true});
            } else {
                obj[key] = value;
            }
            return obj;
        }

        var TabulatePagingService = function TabulatePagingService() {
                var _this = this;

                _classCallCheck(this, TabulatePagingService);

                _defineProperty(this, "countPages", function (total, perPage) {
                    return Math.ceil(parseInt(total, 10) / parseInt(perPage, 10));
                });

                _defineProperty(this, "updatePaging", function (items, filter, pageNumber, numPerPage) {
                    var begin = (pageNumber - 1) * numPerPage,
                        end = begin + numPerPage,
                        paged = items; // if a filter value exists, filter the items before paging

                    if (filter) {
                        paged = _this.getFilteredPage(items, filter);
                    }

                    var totalPages = Math.ceil(paged.length / numPerPage);

                    if (pageNumber > totalPages) {
                        begin = 0;
                        end = begin + totalPages;
                        pageNumber = 1;
                    }

                    return {
                        items: paged.slice(begin, end),
                        totalPages: totalPages,
                        pageNumber: pageNumber,
                        search: filter
                    };
                });

                _defineProperty(this, "getFilteredPage", function (items, term) {
                    var paged = [];
                    var l = items.length;
                    term = term.toString().toLowerCase();
                    var i, // loop index
                        j, // inner loop index
                        o, // the object plucked from items array
                        keys, pushed;

                    for (i = 0; i < l; i += 1) {
                        o = items[i];
                        pushed = false;

                        if (_typeof(o) === 'object') {
                            keys = Object.keys(o);

                            for (j = 0; j < keys.length; j++) {
                                if (!pushed && o[keys[j]] && o[keys[j]].toString().toLowerCase().includes(term)) {
                                    paged.push(o);
                                    pushed = true;
                                }
                            }
                        } else {
                            if (o && o.toLowerCase().includes(term)) {
                                paged.push(o);
                            }
                        }
                    }

                    return paged;
                });

                _defineProperty(this, "setCurrentPage", function (i, j) {
                    return j === undefined ? i - 1 > 0 ? i - 1 : i : i + 1 <= j ? i + 1 : i;
                });
            }
            /**
             *
             * @param {any} total
             * @param {any} perPage
             */
        ;

        exports.TabulatePagingService = TabulatePagingService;

        _defineProperty(TabulatePagingService, "name", 'tabulatePagingService');

    }, {}],
    24: [function (require, module, exports) {
        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.TabulateResource = void 0;

        function _typeof(obj) {
            "@babel/helpers - typeof";
            if (typeof Symbol === "function" && typeof Symbol.iterator === "symbol") {
                _typeof = function _typeof(obj) {
                    return typeof obj;
                };
            } else {
                _typeof = function _typeof(obj) {
                    return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj;
                };
            }
            return _typeof(obj);
        }

        function _classCallCheck(instance, Constructor) {
            if (!(instance instanceof Constructor)) {
                throw new TypeError("Cannot call a class as a function");
            }
        }

        function _defineProperty(obj, key, value) {
            if (key in obj) {
                Object.defineProperty(obj, key, {value: value, enumerable: true, configurable: true, writable: true});
            } else {
                obj[key] = value;
            }
            return obj;
        }

        var TabulateResource = function TabulateResource(notificationsService, assetsService, $q, editorState) {
            var _this = this;

            _classCallCheck(this, TabulateResource);

            _defineProperty(this, "fieldTypes", function () {
                return [{
                    label: 'Text string',
                    value: 'string'
                }, {
                    label: 'Textarea',
                    value: 'textarea'
                }, {
                    label: 'Rich text',
                    value: 'rte'
                }, {
                    label: 'Number',
                    value: 'number'
                }, {
                    label: 'Email',
                    value: 'email'
                }, {
                    label: 'Telephone',
                    value: 'tel'
                }, {
                    label: 'Date',
                    value: 'date'
                }, {
                    label: 'Url',
                    value: 'url'
                }, {
                    label: 'Color',
                    value: 'color'
                }, {
                    label: 'Linked',
                    value: 'linked'
                }];
            });

            _defineProperty(this, "JSONtoCSV", function (json, header) {
                var arr = _typeof(json) !== 'object' ? JSON.parse(json) : json;
                var headerKeys = [];
                var csv = '',
                    row,
                    i,
                    j,
                    o; //This condition will generate the Label/Header

                if (header) {
                    row = ''; // iterate config as header, taking unique display names

                    for (i = 0; i < header.length; i += 1) {
                        var name = header[i].displayName;

                        if (headerKeys.indexOf(name) === -1) {
                            headerKeys.push(name);
                            row += name + ',';
                        }
                    } // trim trailing comma


                    row = row.slice(0, -1); //append Label row with line break

                    csv += row + '\r\n';
                } //1st loop is to extract each row


                for (i = 0; i < arr.length; i += 1) {
                    row = '';
                    o = arr[i];

                    for (j = 0; j < headerKeys.length; j += 1) {
                        var headerKey = o[headerKeys[j]];

                        if (headerKey !== undefined) {
                            var data = typeof headerKey === 'string' ? headerKey : JSON.stringify(headerKey);
                            row += "\"".concat(data.replace(/"/gi, '""'), "\",");
                        } else {
                            row += '"",';
                        }
                    } // trim trailling comma


                    row = row.slice(0, -1); //add a line break after each row

                    csv += row + '\r\n';
                }

                return csv;
            });

            _defineProperty(this, "CSVtoArray", function (strData, strDelimiter) {
                strDelimiter = strDelimiter || ',';
                var objPattern = new RegExp("(\\".concat(strDelimiter, "|\\r?\\n|\\r|^)(?:\"([^\"]*(?:\"\"[^\"]*)*)\"|([^\"\\").concat(strDelimiter, "\\r\\n]*))"), 'gi');
                var arrData = [[]];
                var arrMatches, strMatchedDelimiter, strMatchedValue;

                while (arrMatches = objPattern.exec(strData)) {
                    strMatchedDelimiter = arrMatches[1];

                    if (strMatchedDelimiter.length && strMatchedDelimiter !== strDelimiter) {
                        // Since we have reached a new row of data,
                        // add an empty row to our data array.
                        arrData.push([]);
                    }

                    if (arrMatches[2]) {
                        strMatchedValue = arrMatches[2].replace(new RegExp('""', 'g'), '"');
                    } else {
                        strMatchedValue = arrMatches[3];
                    }

                    arrData[arrData.length - 1].push(strMatchedValue);
                }

                return arrData;
            });

            _defineProperty(this, "loadGoogleMaps", function (apiKey) {
                var deferred = _this.$q.defer();

                if (!apiKey) {
                    return deferred.resolve(false);
                }

                var loadMapsApi = function loadMapsApi() {
                    if (!window.google.maps) {
                        window.google.load('maps', '3', {
                            other_params: "key=".concat(apiKey),
                            callback: function callback() {
                                return deferred.resolve(true);
                            }
                        });
                    } else if (window.google.maps) {
                        deferred.resolve(true);
                    }
                };

                if (!window.google) {
                    _this.assetsService.loadJs('https://www.google.com/jsapi').then(function () {
                        return loadMapsApi();
                    });
                } else {
                    loadMapsApi();
                }

                return deferred.promise;
            });

            _defineProperty(this, "geocode", function (d) {
                if (!window.google.maps) return d;
                var keys = Object.keys(d);
                var p = keys.indexOf('Address') !== -1 ? 'Address' : '';

                if (p !== '' && confirm('Found location data - geocode it?')) {
                    var geoStr = "_".concat(p);
                    var geocoder = new google.maps.Geocoder();
                    var address = d[p];
                    geocoder.geocode({
                        'address': address
                    }, function (results, status) {
                        if (status === google.maps.GeocoderStatus.OK) {
                            d[geoStr] = results[0].geometry.location;
                            d.lat = results[0].geometry.location.lat();
                            d.lng = results[0].geometry.location.lng();

                            _this.notificationsService.success('Success', 'Geocode successful');
                        } else {
                            d[geoStr] = undefined;

                            _this.notificationsService.error('Error', "Geocode failed: ".concat(status));
                        }
                    });
                }

                return d;
            });

            _defineProperty(this, "setLabels", function (items, force, format) {
                if (!items) return;

                if (Array.isArray(items)) {
                    items.forEach(function (item) {
                        return parseLabel(item);
                    });
                } else {
                    parseLabel(items);
                } // construct the label for the item/s, based on the pattern defined in settings
                // labels can refer to object properties - defined by parent|child in the label


                function parseLabel(o) {
                    if (force || o._label === undefined) {
                        var pattern = /{(.*?)}/g;
                        var m;
                        var label = '';

                        do {
                            m = pattern.exec(format);

                            if (m) {
                                var labelKeys = m[1].split('|');
                                var replacementText = '';

                                if (labelKeys[0]) {
                                    replacementText = labelKeys.length === 1 ? o[labelKeys[0]] : o[labelKeys[0]][labelKeys[1]];
                                }

                                label = label.length ? label.replace(m[0], replacementText) : format.replace(m[0], replacementText);
                            }
                        } while (m);

                        o._label = label;
                    }
                }
            });

            _defineProperty(this, "getTabulateEditors", function (currentAlias, variant) {
                // stores refs to other editors for mapping
                var tabulateEditors = [];
                /* set values for the mappings - can map to any other tabulate instance on the node */

                variant.tabs.forEach(function (v) {
                    v.properties.forEach(function (vv) {
                        if (currentAlias !== vv.alias && vv.editor === 'NW.Tabulate') {
                            tabulateEditors.push(vv);
                        }
                    });
                });
                return tabulateEditors;
            });

            _defineProperty(this, "updateMappedEditor", function (source, previous, mappings, alias, variant) {
                if (!mappings || !mappings.length) return;

                var tabulateEditors = _this.getTabulateEditors(alias, variant);

                mappings.forEach(function (m) {
                    var mappingElement = tabulateEditors.find(function (x) {
                        return x.alias === m.targetEditor.alias;
                    });
                    if (!mappingElement) return;
                    var updatedCount = 0;
                    var fromKey = m.sourceProperty.displayName;
                    var toKey = m.targetProperty.displayName; // if the mapped field is also defined as a linked property, use the toKey_label field
                    // since linked fields store the label

                    if (mappingElement.value.data[0].hasOwnProperty(toKey + '_link')) {
                        fromKey = '_label';
                    }

                    var rowsToUpdate = mappingElement.value.data.filter(function (d) {
                        return d[toKey] === previous[fromKey];
                    });
                    rowsToUpdate.forEach(function (row) {
                        row[toKey] = source[fromKey];
                        row.disabled = !!source.disabled;

                        _this.setLabels(row, true, mappingElement.value.settings.label);

                        updatedCount += 1;
                    });
                    if (updatedCount === 0) return;

                    _this.notificationsService.warning("".concat(updatedCount, " linked row").concat(updatedCount > 1 ? 's' : '', " modified in ").concat(m.targetEditor.label));
                });
            });

            this.notificationsService = notificationsService;
            this.assetsService = assetsService;
            this.$q = $q;
            this.editorState = editorState;
        };

        exports.TabulateResource = TabulateResource;

        _defineProperty(TabulateResource, "name", 'tabulateResource');

    }, {}]
}, {}, [16, 18, 19, 20, 21, 17, 23, 24, 22]);

//# sourceMappingURL=tabulate.js.map
