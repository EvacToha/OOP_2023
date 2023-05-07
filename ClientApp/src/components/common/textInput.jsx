import Form from "react-bootstrap/Form";

function TextInput({ isDisabled, value, onChange, isValid = true }) {
  return (
    <Form.Group className="mb-3" controlId="validationCustom03">
      <Form.Label>Example textarea</Form.Label>
      <Form.Control
        as="textarea"
        rows={3}
        value={value}
        onChange={onChange}
        isInvalid={!isValid}
        disabled={isDisabled}
      />
    </Form.Group>
  );
}

export default TextInput;
