# What is REST

representation state transfer

# The 6 Constraints of REST APIs

REST (Representational State Transfer) is an architectural style for designing networked applications. A truly RESTful API adheres to the following six constraints, which were introduced by Roy Fielding.

---


## 1. Client-Server Architecture

- **Definition**: Separation of concerns between client and server.
- **Purpose**: Improves portability of the client and scalability of the server.
- **Example**: A web browser (client) makes requests to an API server, which handles business logic and data storage.

---

## 2. Statelessness

- **Definition**: Each request from a client must contain all the information needed to process the request. The server does not store session state.
- **Purpose**: Simplifies server design and increases scalability.
- **Example**: Clients include authentication tokens in each request instead of relying on session data stored on the server.

---

## 3. Cacheability

- **Definition**: API responses must explicitly indicate whether they are cacheable.
- **Purpose**: Improves performance by reducing unnecessary server calls.
- **Example**: A `Cache-Control` header in a response specifies if and how long the response can be cached.

---

## 4. Uniform Interface

- **Definition**: A consistent interface across the API to simplify and decouple architecture.
- **Purpose**: Enables independent development of client and server.

### Guiding Principles:

1. **Identification of Resources**  
   Resources are identified using URIs (e.g., `/api/products/123`). Each URI represents a unique resource.

2. **Manipulation of Resources Through Representations**  
   Clients interact with resources using representations (usually JSON or XML). They can modify a resource's state by sending updated representations via HTTP methods (e.g., `PUT`, `PATCH`).

3. **Self-Descriptive Messages**  
   Each message contains enough information to describe how it should be processed (e.g., headers like `Content-Type`, status codes, etc.).

4. **Hypermedia as the Engine of Application State (HATEOAS)**  
   Clients discover available actions through hyperlinks provided dynamically by the server (e.g., a product resource includes a link to related categories or reviews).

---

## 5. Layered System

- **Definition**: The architecture can be composed of hierarchical layers (e.g., proxies, load balancers).
- **Purpose**: Improves scalability, security, and manageability.
- **Example**: A client might not know whether it is communicating directly with the server or through an intermediary like a CDN.

---

## 6. Code on Demand (Optional)

- **Definition**: Servers can send executable code to clients to extend their functionality.
- **Purpose**: Enhances flexibility and reduces the need for client-side logic.
- **Example**: A REST API returns JavaScript code that the client executes.

---

**Note**: The first five constraints are mandatory to be considered RESTful; "Code on Demand" is optional.

