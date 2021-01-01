FROM node:12-alpine
WORKDIR /prime/web-app/
COPY . .
RUN npm install --production
EXPOSE 8080
CMD ["npm", "run", "start:open"]