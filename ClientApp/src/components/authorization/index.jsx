import Form from "react-bootstrap/Form";
import {Button} from "react-bootstrap";
import styles from "./authorization.module.css"
function Authorization() {
    const handleSubmit = () => {
        const data = {login: "3434", password: "3444"};
        fetch("https://localhost:7233/Authorization", {
            mode: "cors",
            method: "post",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        })
            .then((response) => {
                if (response.status !== 200) {
                    throw new Error(response.statusText);
                }

                return response.json();
            })
            .catch((err) => {
                console.log(err)
            });
    }
  return (
      <Form className={styles.formContainer} >
        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control type="email" placeholder="Enter email" />
          <Form.Text className="text-muted">
            We'll never share your email with anyone else.
          </Form.Text>
        </Form.Group>

        <Form.Group className="mb-3" controlId="formBasicPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control type="password" placeholder="Password" />
        </Form.Group>
        <Form.Group className="mb-3" controlId="formBasicCheckbox">
          <Form.Check type="checkbox" label="Check me out" />
        </Form.Group>
        <Button variant="primary" type="submit">
          Submit
        </Button>       
          <Button onClick={handleSubmit}>
          Submit
        </Button>
      </Form>
      
  );
}

export default Authorization;
