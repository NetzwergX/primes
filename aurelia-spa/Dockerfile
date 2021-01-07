FROM node:12-alpine
WORKDIR /prime/web-app/
COPY . .
RUN npm install --production --quiet
RUN npm install webpack webpack-cli --save-dev
EXPOSE 8080

ENTRYPOINT ["npx", "webpack", "serve", "--env", "production"]