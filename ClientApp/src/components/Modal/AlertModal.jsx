// import React from 'react';
// import 'bootstrap/dist/css/bootstrap.min.css';

// const AlertModal = ({ show, onClose, onRetry }) => {
//   if (!show) return null;

//   return (
//     <div className="alert alert-danger alert-dismissible fade show" role="alert" id="modal">
//       <button
//         type="button"
//         className="btn-close"
//         aria-label="Close"
//         onClick={onClose}
//       ></button>
//       <p>
//         <strong>Oh snap!</strong>{' '}
//         <a href="#" className="alert-link" onClick={(e) => e.preventDefault()}>
//           Change a few things up
//         </a>{' '}
//         and try submitting again.
//       </p>
//     </div>
//   );
// };

// export default AlertModal;


// components/AlertModal.jsx
import React from 'react';
import { Alert, Button, Fade } from 'react-bootstrap';

const AlertModal = ({ show, onClose, onRetry }) => {
  return (
    <Fade in={show}>
      <div>
        {show && (
          <Alert variant="danger" dismissible onClose={onClose} className="custom-alert">
            <Alert.Heading></Alert.Heading>
            <p>
              <strong>  Something went wrong.</strong>{' '}
              <a href="#" onClick={(e) => e.preventDefault()} className="alert-link">
              Try changing a few things
              </a>{' '}
              and submit again.
            </p>
            {/* <div className="d-flex justify-content-end">
              <Button variant="danger" onClick={onRetry} className="me-2">
                Retry
              </Button>
              <Button variant="secondary" onClick={onClose}>
                Close
              </Button>
            </div> */}
          </Alert>
        )}
      </div>
    </Fade>
  );
};

export default AlertModal;

