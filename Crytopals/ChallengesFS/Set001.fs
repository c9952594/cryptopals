module Challenges

open NUnit.Framework
open Base64
open Hex
open Text

[<TestFixture>]
type Challenge01() = 
    [<Test>]
    member this.Solution() = 
        let expectedBase64 = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t"
        let hex = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d"
        let base64 = hex |> bytes_from_hex |> base64_from_bytes

        Assert.AreEqual(expectedBase64, base64)


    [<Test>]
    member this.ConvertHex() = 
        let hex = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d" |> Seq.cast
        
        let toBytes = hex |> bytes_from_hex
        let fromBytes = toBytes |> hex_from_bytes
        
        CollectionAssert.AreEqual(hex, fromBytes)

    [<Test>]
    member this.ConvertText() = 
        let text = "Man" |> Seq.cast

        let toBytes = text |> bytes_from_text
        let fromBytes = toBytes |> text_from_bytes
        
        CollectionAssert.AreEqual(text, fromBytes)


    [<TestCase("Man", "TWFu")>]
    [<TestCase("M", "TQ==")>]
    [<TestCase("Ma", "TWE=")>]
    member this.ConvertBase64(input, expected) = 
        let textBytes = input |> bytes_from_text 

        let base64 = textBytes |> base64_from_bytes
        CollectionAssert.AreEqual(base64, expected)

        let toBytes = base64 |> bytes_from_base64
        CollectionAssert.AreEqual(toBytes, textBytes)
        