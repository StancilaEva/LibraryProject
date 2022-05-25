import Joi from "joi";
export const addressSchema = Joi.object({
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
        'any.invalid': 'county cannot be empty'
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
      })
})
