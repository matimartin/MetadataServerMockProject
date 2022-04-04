metadata-server-mock

go to: https://github.com/piotr-iohk/metadata-server-mock#readme

http://metadata-server-mock.herokuapp.com/

To add new metadata make PR with new file in metadata folder in this repository.

To start locally
Have ruby.
👇
git clone https://github.com/piotr-iohk/metadata-server-mock.git
cd metadata-server-mock
bundle install
./start
Exemplary requests
Query:

$ curl -X POST http://localhost:4441/metadata/query \
-d '{"subjects": ["789ef8ae89617f34c07f7f6a12e4d65146f958c0bc15a97b4ff169f16861707079636f696e",
                  "789ef8ae89617f34c07f7f6a12e4d65146f958c0bc15a97b4ff169f1"]}'


$ curl -X POST http://localhost:4441/metadata/query \
-d '{"subjects": ["789ef8ae89617f34c07f7f6a12e4d65146f958c0bc15a97b4ff169f16861707079636f696e",
                  "789ef8ae89617f34c07f7f6a12e4d65146f958c0bc15a97b4ff169f1",
                  "94d4cdbcffb09ebd4780d94f932a657dc4852530fa8013df66c72d4c676f6f64636f696e"],
     "properties": ["name", "description", "url"]}'

Property:

$ curl -X GET http://localhost:4441/metadata/94d4cdbcffb09ebd4780d94f932a657dc4852530fa8013df66c72d4c676f6f64636f696e/properties/name

{
  "value": "GoodCoin",
  "anSignatures": [
    {
      "publicKey": "eea2aece21d77ee1d363e997f535b10522ad7abd09a247553211c7eb51d9c37e",
      "signature": "35509234021b145f23d5ca53a2dd73701065f4327d05d0788519a3b16dce1e2030d0da2b9f67baea65c7e2bfd20de38c2228493fff53dea0ad00cc2e509be60b"
    }
  ]
}

Metadata:

$ curl -X  GET http://localhost:4441/metadata/789ef8ae89617f34c07f7f6a12e4d65146f958c0bc15a97b4ff169f1

{
  "subject": "789ef8ae89617f34c07f7f6a12e4d65146f958c0bc15a97b4ff169f1",
  "preImage": {
    "value": "3738396566386165383936313766333463303766376636613132653464363531343666393538633062633135613937623466663136396631",
    "hashFn": "sha256"
  },
  "name": {
    "value": "NoAssetNameCoin",
    "anSignatures": [
      {
        "publicKey": "16fc67a3da106d6f9db295a2a39be66bc1cba0bdbca410472191775220e999ab",
        "signature": "0638dc3e34cb2c3cc1ea993a3109bb8f02b9573010f10120d80229b051b72a9421521df7d3af0b895384d1169985c1e0dd532d3e592934f6b614daf9351b650c"
      }
    ]
  },
  "description": {
    "value": "Coin with no asset name",
    "anSignatures": [
      {
        "publicKey": "16fc67a3da106d6f9db295a2a39be66bc1cba0bdbca410472191775220e999ab",
        "signature": "5d6ba8a2a4b8ad2c3f9a69bda905e46c0c2f0aca6389324fdad1feb63d536418b7913d4f191c8d4f16eadd9adf162f08da5ea05f71aa09358d5c490cefd5a80d"
      }
    ]
  }
}