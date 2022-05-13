import * as React from 'react';
import Box from '@mui/material/Box';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import Button from '@mui/material/Button';
import { useState } from 'react';
import SignUpForm from '../Cards/stepperforms/SignUpUserFormJoi';
import AddressForm from '../Cards/stepperforms/AdddressForm';
import { useForm } from 'react-hook-form';
import { joiResolver } from '@hookform/resolvers/joi';
import UnsuccessfulMessage from "../Cards/Toasts/UnsuccessfulMessage";
import { userSchema } from '../../validators/userSchema';
import { signUpUser } from '../../services/RegisterService';
import { Navigate, useNavigate } from 'react-router-dom';
import { Collapse } from '@mui/material';

const steps = ['Enter User Data', 'Enter address'];

export default function HorizontalLinearStepper() {
  const [activeStep, setActiveStep] = useState(0);
  const [errorMessage, setErrorMessage] = useState("");
  const [showMessage, setShowMessage] = useState(false)
  const navigate = useNavigate()

  const { register, handleSubmit, formState: { errors },watch } = useForm({
    resolver: joiResolver(userSchema),
  });
  const [user, setUser] = useState({
    username: '',
    email: '',
    password: '',
    county: '',
    city: '',
    street: '',
    number: 0
  })


  const email = register("email")
  const username = register("username")
  const password = register("password")
  const confirmPassword = register("confirmPassword")
  const county = register("county")
  const city = register("city")
  const street = register("street")
  const number = register("number")

  const handleNext = () => {
    setActiveStep((prevActiveStep) => prevActiveStep + 1);
  };

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };

  const handleReset = () => {
    setActiveStep(0);
  };

  const onSignUpSubmit = async (data) => {
    const response = await signUpUser(user)
    if(response.status===201){
      navigate('/')
    }
    else{
      setShowMessage(true)
      setErrorMessage(response.message)
    }
  }


  const renderToast = () => {
    return (<UnsuccessfulMessage setShowMessage={setShowMessage} message={errorMessage} showMessage={showMessage} />)
  }

  return (
    <Box sx={{ width: '100%', padding: '16px' }}>
      <Stepper activeStep={activeStep}>
        {steps.map((label, index) => {
          const stepProps = {};
          const labelProps = {};
          return (
            <Step key={label} {...stepProps}>
              <StepLabel {...labelProps}>{label}</StepLabel>
            </Step>
          );
        })}
      </Stepper>
      {activeStep === 1 ? (
        <React.Fragment>
          <AddressForm
            setActiveStep={setActiveStep}
            user={user}
            setUser={setUser}
            county={county}
            city={city}
            street={street}
            number={number}
            errors={errors}/>
          <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
            <Button
              color="inherit"
              disabled={activeStep === 0}
              onClick={handleBack}
              sx={{ mr: 1 }}
            >
              Back
            </Button>
            <Box sx={{ flex: '1 1 auto' }} />
            <Button onClick={handleSubmit(onSignUpSubmit)}>
              Finish
            </Button>
          </Box>
        </React.Fragment>
      ) : (
        <React.Fragment>
          <SignUpForm
            setActiveStep={setActiveStep}
            user={user}
            setUser={setUser}
            email={email}
            password={password}
            username={username}
            confirmPassword={confirmPassword}
            errors={errors} />
          <Box  sx={{ display: 'flex', flexDirection: 'row', pt: 2 }} >
          <Box sx={{ flex: '1 1 auto' }} />
          <Button onClick={handleNext}>
            Next
          </Button>
          </Box>
        </React.Fragment>
      )}
      <Collapse in={showMessage}>
            {
            renderToast() 
            }
        </Collapse>
    </Box>
  );
}
