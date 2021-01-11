package net.teumert.prime.api;

import java.util.List;
import java.util.stream.Collectors;

import javax.inject.Inject;
import javax.ws.rs.DefaultValue;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.jboss.resteasy.annotations.jaxrs.PathParam;
import org.jboss.resteasy.annotations.jaxrs.QueryParam;

@Path("/api/prime/")
public class PrimeResource {

	@Inject
	PrimeService service;

	@GET
	@Produces(MediaType.TEXT_PLAIN)
	@Path("fetch/")
	public List<Integer> fetch (
			@QueryParam("after") int after,
			@DefaultValue("100")
			@QueryParam("limit") int limit) {
		return service
			.getPrimes(after)
			.limit(limit)
			.mapToObj(i -> i)
			.collect(Collectors.toList());
	}

	// CAN NOT use int/boolean as return type due to error:
	// Could not find MessageBodyWriter for response object of type:
	// java.lang.Boolean of media type: application/json

	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("check/{candidate}")
	public String check (@PathParam int candidate) {
		return String.valueOf(service.isPrime(candidate));
	}

	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("next/{after}")
	public String next (@PathParam int after) {
		return  String.valueOf(service.nextPrime(after));
	}
}