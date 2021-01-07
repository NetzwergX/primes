package net.teumert.prime.api;

import io.quarkus.test.junit.QuarkusTest;
import org.junit.jupiter.api.Test;

import static io.restassured.RestAssured.given;
import static org.hamcrest.CoreMatchers.is;

@QuarkusTest
public class PrimeResourceTest {

    // @Test
    // public void testHelloEndpoint() {
    //     given()
    //       .when().get("/quarkus-api")
    //       .then()
    //          .statusCode(200)
    //          .body(is("Hello RESTEasy"));
    // }

}