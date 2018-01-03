var assert = require('assert');

var Client = require('node-rest-client').Client;
var client = new Client();

const url = "http://localhost:57230/api/accounts";

describe('Account', function() {
    describe('post', function() {
        it('should return bad request when name is null', function(done) {
            var args = {
                data: { name: null },
                headers: { "Content-Type": "application/json" }
            };
            
            client.post(url, args, function(data, response){
                assert.equal(response.statusCode, 400);
                done();
            });
        });

        it('should return bad request when name is an empty string', function(done) {
            var args = {
                data: { name: "" },
                headers: { "Content-Type": "application/json" }
            };
            
            client.post(url, args, function(data, response){
                assert.equal(response.statusCode, 400);
                done();
            });
        });

    });
});