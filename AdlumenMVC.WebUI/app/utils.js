'use strict';
function validateNumber(event) {
    var key = window.event ? event.keyCode : event.which;

    if (key == 8 || key == 32 || key == 46 || key == 37 || key == 39 || key == 43) {
        return true;
    }
    else if (key < 48 || key > 57) {
        return false;
    }
    else return true;
}

function validateIntegerNumber(event) {
    var key = window.event ? event.keyCode : event.which;

    if (key < 48 || key > 57) {
        return false;
    }
    else return true;
}

function isValidImportedDate(date) {
    var matches = /^(\d{4})[-\/](\d{2})[-\/](\d{2})$/.exec(date);
    if (matches == null) return false;
    var y = matches[1];
    var m = matches[2] - 1;
    var d = matches[3];
    var composedDate = new Date(y, m, d);
    return composedDate.getDate() == d &&
            composedDate.getMonth() == m &&
            composedDate.getFullYear() == y;
}

function isValidImportedTime(time) {
    var isValid = /^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$/.test(time);
    return isValid;
}

function isValidEmail(email) {
    var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
    return re.test(email);
}

function isValidImportedAmount(amount) {
    return !isNaN(parseFloat(amount))
}

function resolveReferences(json) {
    if (!json) {
        return json;
    }
    if (typeof json === 'string' && json.trim() != '') {
        try {
            json = JSON.parse(json);
        }
        catch (ex) {
            console.log('resolveReferences -> ', ex);
            return json;
        }
    }

    var byid = {}, // all objects by id
        refs = []; // references to objects that could not be resolved

    json = (function recurse(obj, prop, parent) {
        if (typeof obj !== 'object' || !obj) // a primitive value
            return obj;
        if (Object.prototype.toString.call(obj) === '[object Array]') {
            for (var i = 0; i < obj.length; i++)
                // check also if the array element is not a primitive value
                if (typeof obj[i] !== 'object' || !obj[i]) // a primitive value
                    continue;
                else if ('$ref' in obj[i])
                    obj[i] = recurse(obj[i], i, obj);
                else
                    obj[i] = recurse(obj[i], prop, obj);
            return obj;
        }
        if ('$ref' in obj) { // a reference
            var ref = obj.$ref;
            if (ref in byid)
                return byid[ref];
            // else we have to make it lazy:
            refs.push([parent, prop, ref]);
            return;
        }
        else if ('$id' in obj) {
            var id = obj.$id;
            //delete obj.$id;
            //if ("$values" in obj) // an array
            //    obj = obj.$values.map(recurse);
            //else // a plain object
            byid[id] = obj;
            for (var prop in obj)
                obj[prop] = recurse(obj[prop], prop, obj);
        }
        return obj;
    })(json); // run it!

    for (var i = 0; i < refs.length; i++) { // resolve previously unknown references
        var ref = refs[i];
        ref[0][ref[1]] = byid[ref[2]];
        // Notice that this throws if you put in a reference at top-level
    }
    return json;
}

function decycle(json) {
    var catalog = {};
    var newJson = decycle2(json, catalog);
    return newJson;
}
//JsonNetDecycle.js
function decycle2(obj, catalog) {
    var i; // The loop counter
    var name; // Property name
    var nu; // The new object or array
    switch (typeof obj) {
        case "object":
            if (obj === null ||
                obj instanceof Boolean ||
                obj instanceof Date ||
                obj instanceof Number ||
                obj instanceof RegExp ||
                obj instanceof String) {
                return obj;
            }
            if (Object.prototype.toString.apply(obj) === "[object Array]") {
                nu = [];
                for (i = 0; i < obj.length; i += 1) {
                    nu[i] = decycle2(obj[i], catalog);
                }
            }
            else {
                if ('$id' in obj) {
                    if (obj.$id in catalog) {
                        return { $ref: obj.$id };
                    }
                    catalog[obj.$id] = obj;
                }
                nu = {};
                for (name in obj) {
                    if (Object.prototype.hasOwnProperty.call(obj, name)) {
                        nu[name] = decycle2(obj[name], catalog);
                    }
                }
            }
            return nu;
        case "number":
        case "string":
        case "boolean":
        default:
            return obj;
    }
}

//Esta funcion no se usa, solo la guarde por si acaso
function parseAndResolve(json) {
    var refMap = {};

    return JSON.parse(json, function(key, value) {
        if (key === '$id') {
            refMap[value] = this;
            // return undefined so that the property is deleted
            return value;
        }

        if (value && value.$ref) { return refMap[value.$ref]; }

        return value;
    });
}

function loadScript(src, callback) {
    var script = document.createElement('script');
    script.type = 'text/javascript';
    if (callback) script.onload = callback;
    document.getElementsByTagName('body')[0].appendChild(script);
    script.src = src;
}