import Joi from "joi";
export const userSchema = Joi.object({
    email: Joi.string().email({tlds: { allow: false } }).required().messages({
        'string.base': `invalid email`,
        'string.empty': `email cannot be empty`,
        'string.email': `enter a valid email`,
        'any.required': `email is required`
      }),
    username: Joi.string().min(4).required().messages({
        'string.base': `invalid user`,
        'string.empty': `username cannot be empty`,
        'any.required': `username is required`
      }),
    password: Joi.string().min(4).required().messages({
        'string.base': `invalid password`,
        'string.empty': `password cannot be empty`,
        'any.required': `password is required`
      }),
    confirmPassword: Joi.string().equal(Joi.ref('password')).required().messages({
        'string.base': `invalid confirm password`,
        'string.empty': `confirm password cannot be empty`,
        'any.required': `confirm password is required`,
        'any.equal': `different inputs` // nu e bine, care e?
      }),
    city: Joi.string().required().invalid("Empty","").messages({
        'string.base': `invalid city`,
        'string.empty': `city cannot be empty`,
        'any.required': `city is required`,
        'any.invalid': 'city cannot be empty'
      }),
    county: Joi.string().required().invalid("Empty","").messages({
        'string.base': `invalid county`,
        'string.empty': `county cannot be empty`,
        'any.required': `county is required`,
        'any.invalid': 'city cannot be empty'
      }),
    street: Joi.string().required().messages({
        'string.base': `invalid street`,
        'string.empty': `street cannot be empty`,
        'any.required': `street is required` 
      }),
    number: Joi.number().required().greater(0).messages({
        'number.base': 'invalid number',
        'any.required': `number is required`,
        'number.greater': `number must be greater than 0`
      }),
})

